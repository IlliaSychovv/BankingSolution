namespace BankingSolution.Application.DTO.Account;

public record CreateAccountDto
{ 
    public string AccountNumber { get; set; } 
    public string AccountName { get; set; }
    public decimal Balance { get; set; }
}