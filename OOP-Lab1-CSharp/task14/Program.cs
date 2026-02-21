using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        bool result = false;

        if (n % 9 == 0 || n % 11 == 0 || n % 13 == 0)
        {
            result = true;
            Console.WriteLine(result);
        }
        else
        {
            result = false;
            Console.WriteLine(result);
        }
    }
}