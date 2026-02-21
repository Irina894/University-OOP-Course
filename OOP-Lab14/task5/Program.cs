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
        Func<int, int> add = n => n + 1;
        Func<int, int> multiply = n => n * 2;
        Func<int, int> subtract = n => n - 1;

        Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            if (command == "add")
            {
                numbers = numbers.Select(add).ToList();
            }
            else if (command == "multiply")
            {
                numbers = numbers.Select(multiply).ToList();
            }
            else if (command == "subtract")
            {
                numbers = numbers.Select(subtract).ToList();
            }
            else if (command == "print")
            {
                print(numbers);
            }
        }
    }
}
