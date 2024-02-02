using FinancialSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialSystemAPI.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountManager> AccountManagers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<BoxCash> BoxCashs { get; set; }
    public DbSet<TransactionCash> TransactionCashs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
