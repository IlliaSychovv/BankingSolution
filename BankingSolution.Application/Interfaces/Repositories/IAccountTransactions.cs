using Banking.Solution.Domain.Entity;

namespace BankingSolution.Application.Interfaces.Repositories;

public interface IAccountTransactions
{
    Task<Account> DepositAsync(Account accountInput);
    Task<Account> WithdrawAsync(Account accountInput);
    Task<Transaction> TransferAsync(Transaction transaction);
}