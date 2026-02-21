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

        List<Predicate<string>> filters = new List<Predicate<string>>();

        string input;
        while ((input = Console.ReadLine()) != "Print")
        {
            string[] parts = input.Split(';', 3);
            string command = parts[0];
            string filterType = parts[1];
            string filterParam = parts[2];

            Predicate<string> predicate = name =>
            {
                return filterType switch
                {
                    "Starts with" => name.StartsWith(filterParam),
                    "Ends with" => name.EndsWith(filterParam),
                    "Length" => name.Length == int.Parse(filterParam),
                    "Contains" => name.Contains(filterParam),
                    _ => false
                };
            };

            if (command == "Add filter")
            {
                filters.Add(predicate);
            }
            else if (command == "Remove filter")
            {
                filters.RemoveAll(p =>
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (p(guests[i]) != predicate(guests[i]))
                            return false;
                    }
                    return true;
                });
            }
        }

        foreach (var filter in filters)
        {
            guests.RemoveAll(filter);
        }

        // 4️⃣ Вивід
        Console.WriteLine(string.Join(" ", guests));
    }
}
