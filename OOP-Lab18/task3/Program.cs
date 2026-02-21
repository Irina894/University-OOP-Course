using System;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Ініціалізація контексту для тесту
            using (var context = new FootballBettingContext())
            {
                // Створення бази даних, якщо її немає (або для першого запуску міграцій)
                context.Database.EnsureCreated();

                Console.WriteLine("Database created or already exists.");
                Console.WriteLine("Football Betting System is ready!");
            }
        }
    }
}