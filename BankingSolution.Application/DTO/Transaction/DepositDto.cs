namespace BankingSolution.Application.DTO.Transaction;

public record DepositDto
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
}