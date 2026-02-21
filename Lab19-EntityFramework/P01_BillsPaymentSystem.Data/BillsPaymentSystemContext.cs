using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data.EntityConfig;
using P01_BillsPaymentSystem.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace P01_BillsPaymentSystem.Data
{
    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext() { }

        public BillsPaymentSystemContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
        }

        public void PayBills(int userId, decimal amount)
        {
            if (amount <= 0)
            {
                return; 
            }

            var user = this.Users
                .Where(u => u.UserId == userId)
                .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.CreditCard)
                .FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentException($"User with ID {userId} not found.");
            }

            var paymentMethods = user.PaymentMethods
                .OrderBy(pm => pm.Type) 
                .ThenBy(pm => pm.Id)  
                .ToArray();

            decimal totalAvailable = paymentMethods
                .Sum(pm =>
                    pm.BankAccount?.Balance ?? 
                    pm.CreditCard?.LimitLeft ??
                    0m
                );

            if (totalAvailable < amount)
            {
                Console.WriteLine("Недостатньо коштів!");
                return;
            }

            decimal amountLeftToPay = amount;

            foreach (var pm in paymentMethods)
            {
                if (amountLeftToPay <= 0)
                {
                    break; 
                }

                decimal available = 0m;

                if (pm.BankAccount != null)
                {
                    available = pm.BankAccount.Balance;
                    decimal payAmount = Math.Min(amountLeftToPay, available);

                    pm.BankAccount.Withdraw(payAmount);
                    amountLeftToPay -= payAmount;
                }
                else if (pm.CreditCard != null)
                {
                    available = pm.CreditCard.LimitLeft;
                    decimal payAmount = Math.Min(amountLeftToPay, available);

                    pm.CreditCard.Withdraw(payAmount);
                    amountLeftToPay -= payAmount;
                }
            }

            if (amountLeftToPay == 0)
            {
                this.SaveChanges();
                Console.WriteLine($"Bills paid successfully! Total amount: {amount:F2}");
            }
        }
    }
}