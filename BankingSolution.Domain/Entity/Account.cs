namespace Banking.Solution.Domain.Entity;

public class Account
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } 
    public string AccountName { get; set; }
    public decimal Balance { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}