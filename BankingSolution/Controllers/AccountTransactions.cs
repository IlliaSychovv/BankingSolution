using BankingSolution.Application.DTO_s.Transaction;
using BankingSolution.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingSolution.Controllers;

[ApiController]
[Route("api/v1/transactions")]
public class AccountTransactions : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public AccountTransactions(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit([FromBody] DepositDto dto)
    {
        var result = await _transactionService.Deposit(dto);
        return Ok(result);
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw([FromBody] WithdrawDto dto)
    {
        var result = await _transactionService.Withdraw(dto);
        return Ok(result);
    }

    [HttpPost("transfer")]
    public async Task<IActionResult> Transfer([FromBody] TransferDto dto)
    {
        var result = await _transactionService.Transfer(dto);
        return Ok(result);
    }
}