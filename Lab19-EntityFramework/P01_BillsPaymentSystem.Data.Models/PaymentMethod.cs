using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        public PaymentMethodType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int? BankAccountId { get; set; }
        public BankAccount? BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard? CreditCard { get; set; }
    }
}