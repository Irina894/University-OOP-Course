using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.BankAccountId);

            builder.Property(ba => ba.BankName)
                   .HasMaxLength(50)
                   .IsUnicode(true)
                   .IsRequired();

            builder.Property(ba => ba.SwiftCode)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired();

            builder.HasOne(ba => ba.PaymentMethod)
                   .WithOne(pm => pm.BankAccount)
                   .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId)
                   .IsRequired(false); 
        }
    }
}