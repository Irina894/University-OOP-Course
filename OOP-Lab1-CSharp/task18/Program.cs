using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int factorial = 1;
        if (n > 0)
        {
            for (int i = 2; i <= n; i++)
            {
                factorial = factorial * i;
            }
            Console.WriteLine(factorial);
        }
        else
        {
            Console.WriteLine("Not valid");
        }
    }
}