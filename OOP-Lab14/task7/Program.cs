using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<string> names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Predicate<string> lengthCheck = name => name.Length <= n;
        foreach (var name in names)
        {
            if (lengthCheck(name))
            {
                Console.WriteLine(name);
            }
        }
    }
}
