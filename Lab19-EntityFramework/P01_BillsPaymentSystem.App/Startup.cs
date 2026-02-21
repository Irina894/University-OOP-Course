using System;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;

namespace P01_BillsPaymentSystem.App
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var context = new BillsPaymentSystemContext())
            {
                context.Database.Migrate();

                DbInitializer.Seed(context);

                int userIdToTest = 2;
                UserInterface.GetUserDetails(context, userIdToTest);
                Console.WriteLine(new string('=', 50));

                while (true)
                {
                    Console.WriteLine("\nВведіть суму для оплати (або 'exit' для виходу):");
                    string? input = Console.ReadLine();

                    if (input?.ToLower() == "exit")
                    {
                        break;
                    }

                    if (decimal.TryParse(input, out decimal amount) && amount > 0)
                    {
                        Console.WriteLine($"\nСпроба оплати рахунку на суму: {amount:F2}");
                        try
                        {
                            context.PayBills(userIdToTest, amount);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }

                        Console.WriteLine("\n--- ОНОВЛЕНИЙ СТАН КОРИСТУВАЧА ---");
                        UserInterface.GetUserDetails(context, userIdToTest);
                        Console.WriteLine(new string('=', 50));
                    }
                    else
                    {
                        Console.WriteLine("Недійсна сума. Будь ласка, введіть додатне число.");
                    }
                }

        Console.WriteLine("Database migration and seeding complete.");

                var card = context.CreditCards.FirstOrDefault(c => c.Limit == 3000m);
                if (card != null)
                {
                    Console.WriteLine($"\nКредитна картка Limit: {card.Limit}, Заборгованість: {card.MoneyOwed}, Залишок: {card.LimitLeft}");
                }

                UserInterface.GetUserDetails(context, 1);

                UserInterface.GetUserDetails(context, 99);

                Console.WriteLine("\n--- ТЕСТ ОПЛАТИ РАХУНКІВ ---");
                decimal billAmount = 2000m;


                try
                {
                    context.PayBills(1, billAmount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during payment: {ex.Message}");
                }
                UserInterface.GetUserDetails(context, 1);

                decimal largeBillAmount = 5000m;
                Console.WriteLine($"\n--- ТЕСТ НЕДОСТАТНЬО КОШТІВ (СУМА: {largeBillAmount:F2}) ---");

                try
                {
                    context.PayBills(1, largeBillAmount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during payment: {ex.Message}");
                }
            }
        }
    }
}