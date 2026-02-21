using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        int n = int.Parse(Console.ReadLine());

        Predicate<int> divisible = x => x % n == 0;

        Func<List<int>, List<int>> reverseAndFilter = nums =>
            nums
            .Where(x => !divisible(x)) 
            .Reverse()               
            .ToList();

        List<int> result = reverseAndFilter(numbers);

        Console.WriteLine(string.Join(" ", result));
    }
}
