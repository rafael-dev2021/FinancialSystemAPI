namespace FinancialSystemAPI.Models;

public class Account(string accountNumber, decimal balance, string type, string customerId)
{
    public string AccountNumber { get; set; } = accountNumber;
    public decimal Balance { get; set; } = balance;
    public string Type { get; set; } = type;
    public string CustomerId { get; set; } = customerId;
    public Customer? Customer { get; set; }
}
