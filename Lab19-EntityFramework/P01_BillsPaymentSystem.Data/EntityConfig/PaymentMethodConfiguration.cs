using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.Type)
                   .IsRequired();

            builder.HasIndex(pm => new { pm.UserId, pm.BankAccountId, pm.CreditCardId })
                   .IsUnique(true);

            builder.ToTable("PaymentMethods", t => t.HasCheckConstraint("CH_PaymentMethod_Source",
                                                    "([BankAccountId] IS NULL AND [CreditCardId] IS NOT NULL) OR ([BankAccountId] IS NOT NULL AND [CreditCardId] IS NULL)"));
        }
    }
}