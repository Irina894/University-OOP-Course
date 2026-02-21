using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_BillsPaymentSystem.Data
{
    public static class DbInitializer
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            if (!context.Users.Any())
            {
                var users = new User[]
                {
                    new User
                    {
                        FirstName = "Іван",
                        LastName = "Іваненко",
                        Email = "ivan.i@example.com",
                        Password = "hashedpassword1"
                    },
                    new User
                    {
                        FirstName = "Олена",
                        LastName = "Петренко",
                        Email = "olena.p@example.com",
                        Password = "hashedpassword2"
                    }
                };
                context.Users.AddRange(users);
            }
            context.SaveChanges();

            var user1 = context.Users.FirstOrDefault(u => u.Email == "ivan.i@example.com");
            var user2 = context.Users.FirstOrDefault(u => u.Email == "olena.p@example.com");

            var bankAccounts = new BankAccount[]
 {
    new BankAccount(1500.50m, "ПриватБанк", "PBANUA2X"),
    new BankAccount(5000.00m, "Ощадбанк", "OSCHUA1A")
 };
            context.BankAccounts.AddRange(bankAccounts);
           
            var creditCards = new CreditCard[]
            {
    new CreditCard(3000m, 500m, DateTime.Now.AddYears(3)),
    new CreditCard(10000m, 8000m, DateTime.Now.AddYears(1))
            };
            context.BankAccounts.AddRange(bankAccounts);
            context.SaveChanges();

            context.CreditCards.AddRange(creditCards);
            context.SaveChanges();

            var ba1 = context.BankAccounts.FirstOrDefault(b => b.SwiftCode == "PBANUA2X");
            var cc1 = context.CreditCards.FirstOrDefault(c => c.Limit == 3000m);
            var cc2 = context.CreditCards.FirstOrDefault(c => c.Limit == 10000m);

            if (!context.PaymentMethods.Any())
            {
                var paymentMethods = new PaymentMethod[]
                {
                    new PaymentMethod
                    {
                        Type = PaymentMethodType.BankAccount,
                        UserId = user1.UserId,
                        BankAccountId = ba1.BankAccountId,
                        CreditCardId = null 
                    },
                    new PaymentMethod
                    {
                        Type = PaymentMethodType.CreditCard,
                        UserId = user1.UserId,
                        BankAccountId = null,
                        CreditCardId = cc1.CreditCardId 
                    },
                    new PaymentMethod
                    {
                        Type = PaymentMethodType.CreditCard,
                        UserId = user2.UserId,
                        BankAccountId = null,
                        CreditCardId = cc2.CreditCardId
                    }
                };
                context.PaymentMethods.AddRange(paymentMethods);
            }
            context.SaveChanges();
        }
    }
}
