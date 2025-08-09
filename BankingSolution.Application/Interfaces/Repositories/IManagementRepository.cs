using Banking.Solution.Domain.Entity;

namespace BankingSolution.Application.Interfaces.Repositories;

public interface IManagementRepository
{
    Task AddAsync(Account account);
    Task<Account> GetByNumberAsync(string number);
    Task<IReadOnlyList<Account>> GetAllAsync(int pageNumber, int pageSize);
    Task<int> GetTotalCount();
}