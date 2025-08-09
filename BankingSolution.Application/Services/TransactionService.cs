using Banking.Solution.Domain.Entity;
using BankingSolution.Application.DTO_s.Transaction;
using BankingSolution.Application.Interfaces.Repositories;
using BankingSolution.Application.Interfaces.Services;
using Mapster;

namespace BankingSolution.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly IAccountTransactions _accountTransactions;

    public TransactionService(IAccountTransactions accountTransactions)
    {
        _accountTransactions = accountTransactions;
    }

    public async Task<DepositDto> Deposit(DepositDto dto)
    {
        var accountEntity = dto.Adapt<Account>();
        
        var account = await _accountTransactions.DepositAsync(accountEntity);
        
        var result = account.Adapt<DepositDto>();
        return result;
    }

    public async Task<WithdrawDto> Withdraw(WithdrawDto dto)
    {
        var accountEntity = dto.Adapt<Account>();
        
        var account = await _accountTransactions.WithdrawAsync(accountEntity);
        
        var result = account.Adapt<WithdrawDto>();
        return result;
    }

    public async Task<TransferDto> Transfer(TransferDto dto)
    {
        var transactionEntity = dto.Adapt<Transaction>();
        
        var transaction = await _accountTransactions.TransferAsync(transactionEntity);
        
        var result = transaction.Adapt<TransferDto>();
        return result;
    }
}