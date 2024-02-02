using FinancialSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialSystemAPI.Context.Configuration;

public class TransactionCashConfiguration : IEntityTypeConfiguration<TransactionCash>
{
    public void Configure(EntityTypeBuilder<TransactionCash> builder)
    {
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Amount).HasPrecision(18, 2);
        builder.Property(x => x.Type).HasMaxLength(50).IsRequired();
    }
}
