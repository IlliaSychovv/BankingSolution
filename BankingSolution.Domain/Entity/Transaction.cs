namespace Banking.Solution.Domain.Entity;

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string fromAccount { get; set; }
    public string toAccount { get; set; }
}