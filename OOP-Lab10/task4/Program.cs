using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}

public class NameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int lengthComparison = x.Name.Length.CompareTo(y.Name.Length);

        if (lengthComparison != 0)
        {
            return lengthComparison;
        }

        return StringComparer.OrdinalIgnoreCase.Compare(x.Name.Substring(0, 1), y.Name.Substring(0, 1));
    }
}

public class AgeComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}

public class Program
{
    public static void Main()
    {
        var nameComparer = new NameComparer();
        var ageComparer = new AgeComparer();

        SortedSet<Person> peopleByName = new SortedSet<Person>(nameComparer);
        SortedSet<Person> peopleByAge = new SortedSet<Person>(ageComparer);

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            var person = new Person(name, age);

            peopleByName.Add(person);
            peopleByAge.Add(person);
        }

        foreach (var person in peopleByName)
        {
            Console.WriteLine(person);
        }

        foreach (var person in peopleByAge)
        {
            Console.WriteLine(person);
        }
    }
}