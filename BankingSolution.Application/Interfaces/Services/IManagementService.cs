using Banking.Solution.Domain.Entity;
using BankingSolution.Application.DTO_s;
using BankingSolution.Application.DTO_s.Account;

namespace BankingSolution.Application.Interfaces.Services;

public interface IManagementService
{
    Task<CreateAccountDto> AddAccount(CreateAccountDto dto);
    Task<AccountDto> GetAccountByNumber(string number);
    Task<PagedResponse<AccountDto>> GetPagedAccount(int pageNumber, int pageSize);
}