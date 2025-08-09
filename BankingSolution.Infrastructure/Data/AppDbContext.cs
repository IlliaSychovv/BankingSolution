using Banking.Solution.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Banking.Solution.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}