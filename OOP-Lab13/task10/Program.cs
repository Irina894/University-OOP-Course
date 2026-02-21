using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Group { get; set; }

    public Person(string first, string last, int group)
    {
        FirstName = first;
        LastName = last;
        Group = group;
    }
}

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            string[] parts = input.Split(' ');

            string firstName = parts[0];
            string lastName = parts[1];
            int group = int.Parse(parts[2]);

            people.Add(new Person(firstName, lastName, group));
        }

        var grouped =
            from p in people
            group p by p.Group into g
            orderby g.Key
            select new
            {
                Group = g.Key,
                Names = g.Select(x => $"{x.FirstName} {x.LastName}")
            };

        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Group} - {string.Join(", ", group.Names)}");
        }
    }
}
