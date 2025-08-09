using Banking.Solution.Domain.Entity;
using BankingSolution.Application.DTO_s.Account;
using BankingSolution.Application.Interfaces.Repositories;
using BankingSolution.Application.Interfaces.Services;
using Mapster;
using SequentialGuid;

namespace BankingSolution.Application.Services;

public class ManagementService : IManagementService
{
    private readonly IManagementRepository _managementrepository;

    public ManagementService(IManagementRepository repository)
    {
        _managementrepository = repository;
    }

    public async Task<PagedResponse<AccountDto>> GetPagedAccount(int pageNumber, int pageSize)
    {
        var accounts = await _managementrepository.GetAllAsync(pageNumber, pageSize);
        var totalCount = await _managementrepository.GetTotalCount();
        
        var accountDto = accounts.Select(x => x.Adapt<AccountDto>()).ToList();

        return new PagedResponse<AccountDto>
        {
            Items = accountDto,
            TotalCount = totalCount,
            PageSize = pageSize
        };
    }

    public async Task<CreateAccountDto> AddAccount(CreateAccountDto dto)
    {
        var account = dto.Adapt<Account>();
        account.Id = SequentialGuidGenerator.Instance.NewGuid();
        
        await _managementrepository.AddAsync(account);

        return account.Adapt<CreateAccountDto>();
    }
    
    public async Task<AccountDto> GetAccountByNumber(string number)
    {
        var account = await _managementrepository.GetByNumberAsync(number);
        if (account == null)
            throw new Exception("Account not found");
        
        return account.Adapt<AccountDto>();
    }
}