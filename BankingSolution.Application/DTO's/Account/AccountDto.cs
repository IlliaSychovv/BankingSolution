namespace BankingSolution.Application.DTO_s.Account;

public record AccountDto
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } 
    public string AccountName { get; set; }
    public decimal Balance { get; set; }
}