using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] names = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Action<string> print = name => Console.WriteLine(name);

        foreach (string n in names)
        {
            print(n);
        }
    }
}
