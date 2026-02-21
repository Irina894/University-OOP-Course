using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] divisors = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .Where(d => d != 0) 
            .ToArray();

        Predicate<int> divisibleByAll = num =>
        {
            foreach (var d in divisors)
            {
                if (num % d != 0)
                    return false;
            }
            return true;
        };
        for (int i = 1; i <= N; i++)
        {
            if (divisibleByAll(i))
            {
                Console.Write(i + " ");
            }
        }
    }
}
