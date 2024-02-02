using FinancialSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialSystemAPI.Context.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsOne(x => x.AddressObjectValue, address =>
        {
            address.Property(x => x.ZipCode).HasMaxLength(11).IsRequired();
            address.Property(x => x.Country).HasMaxLength(60).IsRequired();
            address.Property(x => x.State).HasMaxLength(30).IsRequired();
            address.Property(x => x.City).HasMaxLength(30).IsRequired();
        });

        ConfigureAddressObjectValue(builder);

        builder.HasData(
            new Customer("622.850.130-51", "Yuji Itadori", "+55 1191234-5678", "YujiItadori@gmail.com"),
            new Customer("352.252.250-81", "Megumi Fushiguro", "+55 1191234-5678", "MegumiFushiguro@gmail.com"),
            new Customer("185.828.510-55", "Nobara Kugisaki", "+55 1191234-5678", "NobaraKugisaki@gmail.com"),
            new Customer("092.863.523-46", "Satoru Gojo", "+55 1191234-5678", "SatoruGojo@gmail.com")
        );
    }

    private static void ConfigureAddressObjectValue(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsOne(x => x.AddressObjectValue, address =>
        {
            address.Property(x => x.ZipCode).HasMaxLength(11).IsRequired();
            address.Property(x => x.Country).HasMaxLength(60).IsRequired();
            address.Property(x => x.State).HasMaxLength(30).IsRequired();
            address.Property(x => x.City).HasMaxLength(30).IsRequired();

            address.HasData(new
            {
                CustomerCPF = "622.850.130-51",
                ZipCode = "984-0032",
                Country = "Japão",
                State = "Miyagi",
                City = "Sendai-shi",
            });

            address.HasData(new
            {
                CustomerCPF = "352.252.250-81",
                ZipCode = "984-0082",
                Country = "Japão",
                State = "Toji Fushiguro",
                City = "Tsumiki Fushiguro",
            });

            address.HasData(new
            {
                CustomerCPF = "185.828.510-55",
                ZipCode = "984-0032",
                Country = "Japão",
                State = "Iwate",
                City = "Morioka",
            });

            address.HasData(new
            {
                CustomerCPF = "092.863.523-46",
                ZipCode = "984-0032",
                Country = "Japão",
                State = "Unlimited",
                City = "Purple Void",
            });
        });
    }
}
