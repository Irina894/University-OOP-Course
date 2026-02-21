using System;
using System.Collections.Generic;
using System.Linq;

public class Person : IComparable<Person>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string City { get; private set; }

    public Person(string name, int age, string city)
    {
        Name = name;
        Age = age;
        City = city;
    }

    public int CompareTo(Person other)
    {
        if (other == null) return 1;

        int nameComparison = this.Name.CompareTo(other.Name);
        if (nameComparison != 0)
        {
            return nameComparison;
        }

        int ageComparison = this.Age.CompareTo(other.Age);
        if (ageComparison != 0)
        {
            return ageComparison;
        }

        return this.City.CompareTo(other.City);
    }
}

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] parts = input.Split();
            if (parts.Length != 3) continue;

            string name = parts[0];
            int age = int.Parse(parts[1]);
            string city = parts[2];

            people.Add(new Person(name, age, city));
        }

        if (people.Count == 0) return;

        if (!int.TryParse(Console.ReadLine(), out int nIndex))
        {
            return;
        }

        if (nIndex < 1 || nIndex > people.Count)
        {
            return;
        }

        Person personToCompare = people[nIndex - 1];

        int equalCount = 0;
        int notEqualCount = 0;
        int totalCount = people.Count;

        foreach (Person currentPerson in people)
        {
            if (currentPerson.CompareTo(personToCompare) == 0)
            {
                equalCount++;
            }
            else
            {
                notEqualCount++;
            }
        }

        if (equalCount <= 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalCount} {notEqualCount} {totalCount}");
        }
    }
}