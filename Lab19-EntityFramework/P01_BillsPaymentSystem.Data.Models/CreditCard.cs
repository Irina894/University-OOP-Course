// CreditCard.cs
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public decimal Limit { get; private set; }

        public decimal MoneyOwed { get; private set; }

        [NotMapped]
        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        public DateTime ExpirationDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;

        private CreditCard() { }
        public CreditCard(decimal limit, decimal moneyOwed, DateTime expirationDate)
        {
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
            this.ExpirationDate = expirationDate;
        }
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.");
            }
            if (this.LimitLeft < amount)
            {
                throw new InvalidOperationException("Credit card limit exceeded.");
            }
            this.MoneyOwed += amount;
        }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.");
            }
            this.MoneyOwed = Math.Max(0, this.MoneyOwed - amount);
        }
    }
}