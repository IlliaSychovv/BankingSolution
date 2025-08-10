namespace BankingSolution.Application.DTO.Transaction;

public record WithdrawDto
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
}