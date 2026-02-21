using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> guests = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string input;
        while ((input = Console.ReadLine()) != "Party!")
        {
            string[] parts = input.Split(' ', 3);
            string command = parts[0];     
            string criteria = parts[1];     
            string value = parts[2];      

            Predicate<string> predicate = name =>
            {
                return criteria switch
                {
                    "StartsWith" => name.StartsWith(value),
                    "EndsWith" => name.EndsWith(value),
                    "Length" => name.Length == int.Parse(value),
                    _ => false
                };
            };

            if (command == "Remove")
            {
                guests.RemoveAll(predicate);
            }
            else if (command == "Double")
            {
                List<string> toAdd = guests.FindAll(predicate);
                guests.AddRange(toAdd);
            }
        }

        if (guests.Count > 0)
        {
            Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }
}
