using Banking.Solution.Domain.Entity;
using BankingSolution.Application.DTO.Account;
using BankingSolution.Application.Interfaces.Repositories;
using BankingSolution.Application.Interfaces.Services;
using Mapster;
using SequentialGuid;

namespace BankingSolution.Application.Services;

public class ManagementService : IManagementService
{
    private readonly IManagementRepository _managementRepository;

    public ManagementService(IManagementRepository repository)
    {
        _managementRepository = repository;
    }

    public async Task<PagedResponse<AccountDto>> GetPagedAccount(int pageNumber, int pageSize)
    {
        var accounts = await _managementRepository.GetAllAsync(pageNumber, pageSize);
        var totalCount = await _managementRepository.GetTotalCount();
        
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
        
        await _managementRepository.AddAsync(account);

        return account.Adapt<CreateAccountDto>();
    }
    
    public async Task<AccountDto> GetAccountByNumber(string number)
    {
        var account = await _managementRepository.GetByNumberAsync(number);
        if (account == null)
            throw new Exception("Account not found");
        
        return account.Adapt<AccountDto>();
    }
}