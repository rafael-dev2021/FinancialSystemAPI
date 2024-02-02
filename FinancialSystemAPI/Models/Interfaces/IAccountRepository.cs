namespace FinancialSystemAPI.Models.Interfaces;

public interface IAccountRepository
{
    Task Credit(string accountNumber, decimal amount);
    Task Debit(string accountNumber, decimal amount);
    Task<decimal> ConsultBalance(string accountNumber);
}
