using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        double power = Math.Pow(10, n - 1);

        if (number / power > 1)
        {
            int nDigit = (number / (int)power) % 10;
            Console.WriteLine("Result:" + nDigit);
        }
        else { }
        Console.WriteLine("-");
    }
}