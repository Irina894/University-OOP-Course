using System;

class Program
{
    static void Main()
    {
        string[] names = Console.ReadLine().Split(' ');

        Action<string> printWithSir = name => Console.WriteLine("Sir " + name);

        foreach (var name in names)
        {
            printWithSir(name);
        }
    }
}
