namespace BankingSolution.Application.DTO.Transaction;

public record TransferDto
{
    public decimal Amount { get; set; }
    public string FromAccount { get; set; }
    public string ToAccount { get; set; }
}