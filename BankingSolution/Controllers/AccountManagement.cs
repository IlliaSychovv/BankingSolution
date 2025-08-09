using BankingSolution.Application.DTO_s.Account;
using BankingSolution.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingSolution.Controllers;

[ApiController]
[Route("api/v1/managements")]
public class AccountManagement : ControllerBase
{
    private readonly IManagementService _managementservice;

    public AccountManagement(IManagementService managementservice)
    {
        _managementservice = managementservice;
    }

    [HttpPost("account")]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountDto dto)
    {
        var account = await _managementservice.AddAccount(dto);
        return CreatedAtAction(nameof(GetClientAccount), new { number = account.AccountNumber }, account);
    }

    [HttpGet("account/{number}")]
    public async Task<IActionResult> GetClientAccount(string number)
    {
        var data = await _managementservice.GetAccountByNumber(number);
        return Ok(data);
    }

    [HttpGet("accounts")]
    public async Task<ActionResult<PagedResponse<AccountDto>>> GetAccounts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var pagedAccounts = await _managementservice.GetPagedAccount(page, pageSize);
        return Ok(pagedAccounts);
    }
}