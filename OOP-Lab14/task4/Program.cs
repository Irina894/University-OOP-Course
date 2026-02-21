using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int start = range[0];
        int end = range[1];

        string command = Console.ReadLine();

        Predicate<int> filter;

        if (command == "even")
        {
            filter = n => n % 2 == 0; 
        }
        else
        {
            filter = n => n % 2 != 0; 
        }

        List<int> numbers = new List<int>();
        for (int i = start; i <= end; i++)
        {
            numbers.Add(i);
        }
        foreach (var number in numbers)
        {
            if (filter(number))
            {
                Console.Write(number + " ");
            }
        }
    }
}
