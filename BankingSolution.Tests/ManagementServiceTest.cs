using Banking.Solution.Domain.Entity;
using BankingSolution.Application.DTO.Account;
using BankingSolution.Application.Interfaces.Repositories;
using BankingSolution.Application.Services;
using Moq;
using Shouldly;

namespace BankingSolution.Tests;

public class ManagementServiceTest
{
    private readonly Mock<IManagementRepository> _managementRepository;
    private readonly ManagementService _service;

    public ManagementServiceTest()
    {
        _managementRepository = new Mock<IManagementRepository>();
        _service = new ManagementService(_managementRepository.Object);
    }

    [Fact]
    public async Task GetPagedAccount_ShouldReturnPagedAccountList_WhenWeCallMethod()
    {
        int pageNumber = 1;
        int pageSize = 10;

        var accounts = new List<Account>()
        {
            new Account { Id = Guid.NewGuid(), AccountNumber = "12345", Balance = 100 },
            new Account { Id = Guid.NewGuid(), AccountNumber = "123456", Balance = 200 }
        };
        
        _managementRepository
            .Setup(x => x.GetAllAsync(pageNumber, pageSize))
            .ReturnsAsync(accounts);
        
        _managementRepository
            .Setup(x => x.GetTotalCount())
            .ReturnsAsync(accounts.Count);
        
        var result = await _service.GetPagedAccount(pageNumber, pageSize);
        
        result.ShouldNotBeNull();
        result.PageSize.ShouldBe(10);
        result.Items.Count().ShouldBe(accounts.Count);
        
        _managementRepository.Verify(x => x.GetAllAsync(pageNumber, pageSize), Times.Once);
    }
    
    [Fact]
    public async Task AddAccount_ShouldCreateAccount_WhenWeCreateAccount()
    {
        var accountDto = new CreateAccountDto
        {
            Id = Guid.NewGuid(),
            AccountNumber = "ABC123",
            AccountName = "AccountName",
            Balance = 100m
        };
        
        _managementRepository
            .Setup(x => x.AddAsync(It.IsAny<Account>()))
            .Returns(Task.CompletedTask);
        
        var result = await _service.AddAccount(accountDto);
        
        result.ShouldNotBeNull();
        result.AccountName.ShouldBe("AccountName");
        _managementRepository.Verify(x => x.AddAsync(It.IsAny<Account>()), Times.Once);
    }

    [Fact]
    public async Task GetAccountByNumber_ShouldReturnAccount_WhenWeCallMethod()
    {
        var account = new Account
        {
            Id = Guid.NewGuid(),
            AccountNumber = "ABC123",
            AccountName = "AccountName",
            Balance = 100m
        };
        
        _managementRepository
            .Setup(x => x.GetByNumberAsync(account.AccountNumber))
            .ReturnsAsync(account);
        
        var result = await _service.GetAccountByNumber(account.AccountNumber);
        
        result.ShouldNotBeNull();
        result.AccountName.ShouldBe("AccountName");
        _managementRepository.Verify(x => x.GetByNumberAsync(account.AccountNumber), Times.Once);
    }
    
    [Fact]
    public async Task GetAccountByNumber_ShouldThrowException_WhenAccountNotFound()
    {
        var accountNumber = "NON_EXISTENT";

        _managementRepository
            .Setup(x => x.GetByNumberAsync(accountNumber))
            .ReturnsAsync((Account)null);  
        
        var result = await Should.ThrowAsync<Exception>(async () =>
            await _service.GetAccountByNumber(accountNumber));

        result.Message.ShouldBe("Account not found");

        _managementRepository.Verify(x => x.GetByNumberAsync(accountNumber), Times.Once);
    }

}