using Banking.Solution.Domain.Entity;
using Banking.Solution.Domain.Exceptions;
using Banking.Solution.Infrastructure.Data;
using BankingSolution.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Banking.Solution.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Account> DepositAsync(Account accountInput)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountInput.AccountNumber);
        
        account.Balance += accountInput.Balance;
        await _context.SaveChangesAsync();
        
        return account;
    }

    public async Task<Account> WithdrawAsync(Account accountInput)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountInput.AccountNumber);
        if (account.Balance < accountInput.Balance)
            throw new InsufficientBalanceException();
        
        account.Balance -= accountInput.Balance;
        await _context.SaveChangesAsync();
        
        return account;
    }
    
    public async Task<Transaction> TransferAsync(Transaction transaction)
    {
        using var dbTransaction = await _context.Database.BeginTransactionAsync();

        var fromAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == transaction.FromAccount);
        var toAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == transaction.ToAccount);

        if (fromAccount.Balance < transaction.Amount)
            throw new InsufficientBalanceException();
    
        try
        {
            fromAccount.Balance -= transaction.Amount;
            toAccount.Balance += transaction.Amount;
            
            await _context.SaveChangesAsync();
            await dbTransaction.CommitAsync();

            return transaction;
        }
        catch
        {
            await dbTransaction.RollbackAsync();
            throw;
        }
    }
}