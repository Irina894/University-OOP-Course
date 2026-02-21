using System;
using System.Collections.Generic;
using System.Linq;

interface IBuyer
{
    int Food { get; }
    void BuyFood();
}

class Citizen : IBuyer
{
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string BirthDate { get; }
    public int Food { get; private set; }

    public Citizen(string name, int age, string id, string birthDate)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
        if (age < 0) throw new ArgumentException("Age cannot be negative.");
        Name = name;
        Age = age;
        Id = id;
        BirthDate = birthDate;
        Food = 0;
    }

    public void BuyFood() => Food += 10;
}

class Rebel : IBuyer
{
    public string Name { get; }
    public int Age { get; }
    public string Group { get; }
    public int Food { get; private set; }

    public Rebel(string name, int age, string group)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
        if (age < 0) throw new ArgumentException("Age cannot be negative.");
        Name = name;
        Age = age;
        Group = group;
        Food = 0;
    }

    public void BuyFood() => Food += 5;
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var people = new Dictionary<string, IBuyer>();

        for (int i = 0; i < n; i++)
        {
            var parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (parts.Length == 4)
                {
                    string personName = parts[0];
                    if (!int.TryParse(parts[1], out int age))
                        throw new ArgumentException("Age must be a number.");
                    string id = parts[2];
                    string birthDate = parts[3];

                    people[personName] = new Citizen(personName, age, id, birthDate);
                }
                else if (parts.Length == 3) 
                {
                    string personName = parts[0];
                    if (!int.TryParse(parts[1], out int age))
                        throw new ArgumentException("Age must be a number.");
                    string group = parts[2];

                    people[personName] = new Rebel(personName, age, group);
                }
                else
                {
                    throw new ArgumentException("Invalid input format.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                i--; 
            }
        }

        string currentName;
        while ((currentName = Console.ReadLine()) != "End")
        {
            if (people.ContainsKey(currentName))
            {
                people[currentName].BuyFood();
            }
        }

        Console.WriteLine(people.Values.Sum(p => p.Food));
    }
}
