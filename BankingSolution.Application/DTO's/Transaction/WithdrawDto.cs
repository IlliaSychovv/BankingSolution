namespace BankingSolution.Application.DTO_s.Transaction;

public record WithdrawDto
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
}