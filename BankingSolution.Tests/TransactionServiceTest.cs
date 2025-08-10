using Banking.Solution.Domain.Entity;
using BankingSolution.Application.DTO.Transaction;
using BankingSolution.Application.Interfaces.Repositories;
using BankingSolution.Application.Services;
using Moq;
using Shouldly;

namespace BankingSolution.Tests;

public class TransactionServiceTest
{
    private readonly Mock<IAccountRepository> _accountTransactions;
    private readonly TransactionService _service;

    public TransactionServiceTest()
    {
        _accountTransactions = new Mock<IAccountRepository>();
        _service = new TransactionService(_accountTransactions.Object);
    }

    [Fact]
    public async Task Deposit_ShouldPutMoney_WhenWeDoTransaction()
    {
        var account = new Account
        {
            AccountNumber = "ABC123",
            Balance = 100m
        };
        
        _accountTransactions
            .Setup(x => x.DepositAsync(It.IsAny<Account>()))
            .ReturnsAsync(account);

        var deposit = new DepositDto
        {
            AccountNumber = "ABC123",
            Balance = 100m
        };
            
        var result = await _service.Deposit(deposit);
        
        result.ShouldNotBeNull();
        result.AccountNumber.ShouldBe("ABC123");
        result.Balance.ShouldBe(100m);
        
        _accountTransactions.Verify(x => x.DepositAsync(It.IsAny<Account>()), Times.Once);
    }

    [Fact]
    public async Task Withdraw_ShouldTakeOffMoney_WhenWeDoTransaction()
    {
        var account = new Account
        {
            AccountNumber = "ABC123",
            Balance = 100m
        };
        
        _accountTransactions
            .Setup(x => x.WithdrawAsync(It.IsAny<Account>()))
            .ReturnsAsync(account);

        var withdraw = new WithdrawDto
        {
            AccountNumber = "ABC123",
            Balance = 100m
        };
        
        var result = await _service.Withdraw(withdraw);
        
        result.ShouldNotBeNull();
        result.AccountNumber.ShouldBe("ABC123");
        result.Balance.ShouldBe(100m);
        
        _accountTransactions.Verify(x => x.WithdrawAsync(It.IsAny<Account>()), Times.Once);
    }

    [Fact]
    public async Task Transfer_ShouldWithdrawAndDepositMoney_WhenWeDoTransaction()
    {
        var transaction = new Transaction
        {
            Amount = 100m,
            FromAccount = "ABC123",
            ToAccount = "XYZ123"
        };
        
        _accountTransactions
            .Setup(x => x.TransferAsync(It.IsAny<Transaction>()))
            .ReturnsAsync(transaction);

        var transfer = new TransferDto
        {
            Amount = 100m,
            FromAccount = "ABC123",
            ToAccount = "XYZ123"
        };
        
        var result = await _service.Transfer(transfer);
        
        result.ShouldNotBeNull();
        result.FromAccount.ShouldBe("ABC123");
        result.ToAccount.ShouldBe("XYZ123");
        result.Amount.ShouldBe(100m);
        
        _accountTransactions.Verify(x => x.TransferAsync(It.IsAny<Transaction>()), Times.Once);
    }
}