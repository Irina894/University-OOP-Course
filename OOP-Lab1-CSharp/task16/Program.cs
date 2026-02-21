using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter c:");
        double c = double.Parse(Console.ReadLine());

        string product;

        if (a == 0 || b == 0 || c == 0)
        {
            product = "Zero";
        }
        else
        {
            int count = 0;

            if (a < 0) count++;
            if (b < 0) count++;
            if (c < 0) count++;

            if (count == 1 || count == 3)
            {
                product = "Negative";
            }
            else
            {
                product = "Positive";
            }
        }
        Console.WriteLine(product);
    }
}