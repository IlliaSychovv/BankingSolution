using BankingSolution.Application.DTO_s.Transaction;

namespace BankingSolution.Application.Interfaces.Services;

public interface ITransactionService
{
    Task<DepositDto> Deposit(DepositDto dto);
    Task<WithdrawDto> Withdraw(WithdrawDto dto);
    Task<TransferDto> Transfer(TransferDto dto);
}