namespace FinancialSystemAPI.Models;

public class TransactionCash(Guid id, DateTime date, decimal amount, string type)
{
    public Guid Id { get; set; } = id;
    public DateTime Date { get; set; } = date;
    public decimal Amount { get; set; } = amount;
    public string Type { get; set; } = type;
    public Account? AccountOrigin { get; set; } 
    public Account? AccountDestination { get; set; } 
}
