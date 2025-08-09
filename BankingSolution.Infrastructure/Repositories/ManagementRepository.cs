using Banking.Solution.Domain.Entity;
using Banking.Solution.Infrastructure.Data;
using BankingSolution.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Banking.Solution.Infrastructure.Repositories;

public class ManagementRepository : IManagementRepository
{
    private readonly AppDbContext _context;

    public ManagementRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Account>> GetAllAsync(int pageNumber, int pageSize)
    {
        var accounts = await _context.Accounts
            .AsNoTracking()
            .OrderByDescending(a => a.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        return accounts;
    }

    public async Task<int> GetTotalCount()
    {
        return await _context.Accounts.CountAsync();
    }

    public async Task AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task<Account?> GetByNumberAsync(string number)
    {
        return await _context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == number);
    }
}