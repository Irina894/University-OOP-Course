using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter c: ");
        int c = int.Parse(Console.ReadLine());

        double average = (a + b + c) / 3.0;
        Console.WriteLine(average);
    }
}