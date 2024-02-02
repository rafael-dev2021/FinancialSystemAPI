using FinancialSystemAPI.Context;
using FinancialSystemAPI.Context.Repositories;
using FinancialSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Repositories;

public class AccountRepositoryTests
{

    [Fact]
    public async void ConsultarSaldo_ShouldReturnBalance()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

        using var dbContext = new AppDbContext(options);
        var account = new Account("50548-7", 1250.95m, "Current Account", "092.863.523-46");
        dbContext.Accounts.Add(account);
        dbContext.SaveChanges();

        var accountRepository = new AccountRepository(dbContext);

        var currentBalance = await accountRepository.ConsultBalance("50548-7");

        Assert.Equal(1250.95m, currentBalance);
    }

    [Fact]
    public async void Credit_ShouldIncreaseBalance()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

        using var dbContext = new AppDbContext(options);
        var account = new Account("92172-7", 2250.45m, "Current Account", "352.252.250-81");
        dbContext.Accounts.Add(account);
        dbContext.SaveChanges();

        var accountRepository = new AccountRepository(dbContext);

        await accountRepository.Credit("92172-7", 50.0m);

        var updatedAccount = dbContext.Accounts.Find("92172-7");
        Assert.Equal(2300.45m, updatedAccount.Balance); 
    }

    [Fact]
    public async void Debit_ShouldDecreaseBalance()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

        using var dbContext = new AppDbContext(options);
        var account = new Account("595540-8", 1200.0m, "Current account", "622.850.130-51");
        dbContext.Accounts.Add(account);
        dbContext.SaveChanges();

        var accountRepository = new AccountRepository(dbContext);

        await accountRepository.Debit("595540-8", 50.0m);

        var updatedAccount = dbContext.Accounts.Find("595540-8");
        Assert.Equal(1150.0m, updatedAccount.Balance);
    }
}
