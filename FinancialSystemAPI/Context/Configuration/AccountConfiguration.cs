using FinancialSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialSystemAPI.Context.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.AccountNumber);
        builder.Property(x => x.Balance).HasPrecision(18, 2).IsRequired();
        builder.Property(x => x.Type).HasMaxLength(50);

        builder.HasOne(x => x.Customer)
                   .WithMany(customer => customer.Accounts)
                   .HasForeignKey(x => x.CustomerId);

        builder.HasData(
            new Account("595540-6", 1250.95m, "Current account", "622.850.130-51"),
            new Account("92172-7", 2250.45m, "Current Account", "352.252.250-81"),
            new Account("196020-2", 4550m, "Current Account", "185.828.510-55"),
            new Account("50548-7", 50m, "Current Account", "092.863.523-46")
            );
    }
}
