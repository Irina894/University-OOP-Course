using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Linq;

namespace P01_BillsPaymentSystem.App
{
    public static class UserInterface
    {
        public static void GetUserDetails(BillsPaymentSystemContext context, int userId)
        {
            var user = context.Users
                .Where(u => u.UserId == userId)
                .Include(u => u.PaymentMethods) 
                    .ThenInclude(pm => pm.BankAccount) 
                .Include(u => u.PaymentMethods) 
                    .ThenInclude(pm => pm.CreditCard) 
                .FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            Console.WriteLine($"\nUser: {user.FirstName} {user.LastName}");
            Console.WriteLine(new string('-', 30));

            var bankAccounts = user.PaymentMethods
                .Where(pm => pm.Type == PaymentMethodType.BankAccount && pm.BankAccount != null)
                .Select(pm => pm.BankAccount)
                .ToArray();

            Console.WriteLine("Bank Accounts:");
            if (bankAccounts.Any())
            {
                foreach (var ba in bankAccounts)
                {
                    Console.WriteLine($"-- ID: {ba.BankAccountId}");
                    Console.WriteLine($"--- Balance: {ba.Balance:F2}");
                    Console.WriteLine($"--- Bank: {ba.BankName}");
                    Console.WriteLine($"--- SWIFT: {ba.SwiftCode}");
                }
            }
            else
            {
                Console.WriteLine("(No bank accounts found)");
            }

            Console.WriteLine(new string('-', 30));

            var creditCards = user.PaymentMethods
                .Where(pm => pm.Type == PaymentMethodType.CreditCard && pm.CreditCard != null)
                .Select(pm => pm.CreditCard)
                .ToArray();

            Console.WriteLine("Credit Cards:");
            if (creditCards.Any())
            {
                foreach (var cc in creditCards)
                {
                    var expDate = cc.ExpirationDate.ToString("yyyy/MM");

                    Console.WriteLine($"-- ID: {cc.CreditCardId}");
                    Console.WriteLine($"--- Limit: {cc.Limit:F2}");
                    Console.WriteLine($"--- Money Owed: {cc.MoneyOwed:F2}");
                    Console.WriteLine($"--- Limit Left: {cc.LimitLeft:F2}"); 
                    Console.WriteLine($"--- Expiration Date: {expDate}");
                }
            }
            else
            {
                Console.WriteLine("(No credit cards found)");
            }
        }
    }
}