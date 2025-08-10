using BankingSolution.Application.DTO.Transaction;

namespace BankingSolution.Application.Interfaces.Services;

public interface ITransactionService
{
    Task<DepositDto> Deposit(DepositDto dto);
    Task<WithdrawDto> Withdraw(WithdrawDto dto);
    Task<TransferDto> Transfer(TransferDto dto);
}