using System;
using System.Collections.Generic;

interface IIdentifiable
{
    string Id { get; }
}

interface IBirthable
{
    string BirthDate { get; }
}

class Citizen : IIdentifiable, IBirthable
{
    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string BirthDate { get; }

    public Citizen(string name, int age, string id, string birthDate)
    {
        Name = name; Age = age; Id = id; BirthDate = birthDate;
    }
}

class Robot : IIdentifiable
{
    public string Model { get; }
    public string Id { get; }

    public Robot(string model, string id)
    {
        Model = model; Id = id;
    }
}

class Pet : IBirthable
{
    public string Name { get; }
    public string BirthDate { get; }

    public Pet(string name, string birthDate)
    {
        Name = name; BirthDate = birthDate;
    }
}

class Program
{
    static void Main()
    {
        var birthables = new List<IBirthable>();
        string line;

        while ((line = Console.ReadLine()) != "End")
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (parts[0] == "Citizen")
                {
                    if (parts.Length != 5)
                        throw new ArgumentException("Invalid input for Citizen! Format: Citizen <Name> <Age> <Id> <BirthDate>");

                    if (!int.TryParse(parts[2], out int age))
                        throw new ArgumentException("Age must be a number!");

                    birthables.Add(new Citizen(parts[1], age, parts[3], parts[4]));
                }
                else if (parts[0] == "Pet")
                {
                    if (parts.Length != 3)
                        throw new ArgumentException("Invalid input for Pet! Format: Pet <Name> <BirthDate>");

                    birthables.Add(new Pet(parts[1], parts[2]));
                }
         
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        string year = Console.ReadLine();

        foreach (var b in birthables)
        {
            if (b.BirthDate.EndsWith(year))
            {
                Console.WriteLine(b.BirthDate);
            }
        }
    }
}
