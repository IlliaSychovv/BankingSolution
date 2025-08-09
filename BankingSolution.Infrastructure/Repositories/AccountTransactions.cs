using Banking.Solution.Domain.Entity;
using Banking.Solution.Infrastructure.Data;
using BankingSolution.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Banking.Solution.Infrastructure.Repositories;

public class AccountTransactions : IAccountTransactions
{
    private readonly AppDbContext _context;

    public AccountTransactions(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Account> DepositAsync(Account accountInput)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountInput.AccountNumber);
        if (account == null)
            throw new Exception("Account not found");
        
        account.Balance += accountInput.Balance;
        await _context.SaveChangesAsync();
        
        return account;
    }

    public async Task<Account> WithdrawAsync(Account accountInput)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == accountInput.AccountNumber);
        if (account == null)
            throw new Exception("Account not found");
        
        if (account.Balance < accountInput.Balance)
            throw new Exception("Insufficient balance");
        
        account.Balance -= accountInput.Balance;
        await _context.SaveChangesAsync();
        
        return account;
    }
    
    public async Task<Transaction> TransferAsync(Transaction transaction)
    {
        using var dbTransaction = await _context.Database.BeginTransactionAsync();

        var fromAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == transaction.fromAccount);
        var toAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == transaction.toAccount);
    
        if (fromAccount == null || toAccount == null)
            throw new Exception("Account not found");
    
        if (fromAccount.Balance < transaction.Amount)
            throw new Exception("Insufficient balance");
    
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