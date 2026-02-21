using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }

        public string BankName { get; set; } = null!;

        public string SwiftCode { get; set; } = null!;

        public PaymentMethod PaymentMethod { get; set; } = null!;


        private BankAccount() { }

        public BankAccount(decimal balance, string bankName, string swiftCode)
        {
            this.Balance = balance;
            this.BankName = bankName;
            this.SwiftCode = swiftCode;
        }
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.");
            }
            if (this.Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds in bank account.");
            }
            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.");
            }
            this.Balance += amount;
        }
    }
}
    
