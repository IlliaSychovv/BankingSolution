using BankingSolution.Application.DTO.Account;

namespace BankingSolution.Application.Interfaces.Services;

public interface IManagementService
{
    Task<AccountDto> AddAccount(CreateAccountDto dto);
    Task<AccountDto> GetAccountByNumber(string number);
    Task<PagedResponse<AccountDto>> GetPagedAccount(int pageNumber, int pageSize);
}