using BankingSolution.Application.DTO.Account;
using BankingSolution.Application.DTO.Transaction;
using BankingSolution.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingSolution.Controllers;

[ApiController]
[Route("api/v1/accounts")]
public class AccountsController : ControllerBase
{
    private readonly IManagementService _managementService;
    private readonly ITransactionService _transactionService;

    public AccountsController(IManagementService managementService,
        ITransactionService transactionService)
    {
        _managementService = managementService;
        _transactionService = transactionService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateAccountDto dto)
    {
        var account = await _managementService.AddAccount(dto);
        return CreatedAtAction(nameof(GetClientAccount), new { number = account.AccountNumber }, account);
    }

    [HttpGet("{number}")]
    public async Task<IActionResult> GetClientAccount(string number)
    {
        var data = await _managementService.GetAccountByNumber(number);
        return Ok(data);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<AccountDto>>> GetAccounts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var pagedAccounts = await _managementService.GetPagedAccount(page, pageSize);
        return Ok(pagedAccounts);
    }
    
    [HttpPost("{accountNumber}/transactions/deposit")]
    public async Task<IActionResult> Deposit(string accountNumber, [FromBody] DepositDto dto)
    {
        dto.AccountNumber = accountNumber;
        var result = await _transactionService.Deposit(dto);
        return Ok(result);
    }

    [HttpPost("{accountNumber}/transactions/withdraw")]
    public async Task<IActionResult> Withdraw(string accountNumber, [FromBody] WithdrawDto dto)
    {
        dto.AccountNumber = accountNumber;
        var result = await _transactionService.Withdraw(dto);
        return Ok(result);
    }

    [HttpPost("{fromAccount}/transactions/transfer")]
    public async Task<IActionResult> Transfer(string fromAccount, [FromBody] TransferDto dto)
    {
        dto.FromAccount = fromAccount;
        var result = await _transactionService.Transfer(dto);
        return Ok(result);
    }
}