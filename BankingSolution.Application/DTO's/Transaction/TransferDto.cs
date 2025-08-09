namespace BankingSolution.Application.DTO_s.Transaction;

public record TransferDto
{
    public decimal Amount { get; set; }
    public string fromAccount { get; set; }
    public string toAccount { get; set; }
}