using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> gems = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<(string filterType, int param)> excludeCommands = new List<(string, int)>();
        string input;

        while ((input = Console.ReadLine()) != "Forge")
        {
            string[] parts = input.Split(';');
            string command = parts[0];
            string filterType = parts[1];
            int param = int.Parse(parts[2]);

            if (command == "Exclude")
            {
                excludeCommands.Add((filterType, param));
            }
            else if (command == "Reverse")
            {
                excludeCommands.Remove((filterType, param));
            }
        }
        HashSet<int> indicesToRemove = new HashSet<int>();

        for (int i = 0; i < gems.Count; i++)
        {
            foreach (var (filterType, param) in excludeCommands)
            {
                int left = i > 0 ? gems[i - 1] : 0;
                int right = i < gems.Count - 1 ? gems[i + 1] : 0;
                int sum = filterType switch
                {
                    "Sum Left" => gems[i] + left,
                    "Sum Right" => gems[i] + right,
                    "Sum Left Right" => gems[i] + left + right,
                   _=> 0
                };

                if (sum == param)
                {
                    indicesToRemove.Add(i);
                    break; 
                }
            }
        }
        
        for (int i = 0; i < gems.Count; i++)
        {
            if (!indicesToRemove.Contains(i))
                Console.Write(gems[i] + " ");
        }
    }
}
