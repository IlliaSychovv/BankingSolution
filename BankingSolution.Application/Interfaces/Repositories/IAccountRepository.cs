using Banking.Solution.Domain.Entity;

namespace BankingSolution.Application.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<Account> DepositAsync(Account accountInput);
    Task<Account> WithdrawAsync(Account accountInput);
    Task<Transaction> TransferAsync(Transaction transaction);
}