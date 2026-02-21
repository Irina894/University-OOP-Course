using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n");
        int n = int.Parse(Console.ReadLine());

        bool result = false;

        if (n > 20 && n % 2 != 0)
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