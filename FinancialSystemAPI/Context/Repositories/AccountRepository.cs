using FinancialSystemAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialSystemAPI.Context.Repositories;

public class AccountRepository(AppDbContext appDbContext) : IAccountRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<decimal> ConsultBalance(string accountNumber)
    {
        var account = await _appDbContext.Accounts
            .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);

        return account?.Balance ?? 0;
    }

    public async Task Credit(string accountNumber, decimal amount)
    {
        var account = await _appDbContext.Accounts
            .FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
        if (account != null)
        {
            account.Balance += amount;
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task Debit(string accountNumber, decimal amount)
    {
        var account = await _appDbContext.Accounts
            .FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
        if (account != null && account.Balance >= amount)
        {
            account.Balance -= amount;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
