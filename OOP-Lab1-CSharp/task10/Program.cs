using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a:");
        double a = (double.Parse(Console.ReadLine()));
        Console.WriteLine("Enter b:");
        double b = (double.Parse(Console.ReadLine()));
        Console.WriteLine("Enter h:");
        double h = (double.Parse(Console.ReadLine()));

        double area = (a + b) / 2.0 * h;
        Console.WriteLine("Result: " + area);
    }
}