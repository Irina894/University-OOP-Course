using System;
using System.Collections.Generic;

class Person
{
    public string Name;
    public int Age;
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public void Show()
    {
        Console.WriteLine($"Name: {Name}  Age: {Age} ");
    }
}

class Family
{
   private List<Person> members = new List<Person>();
    public void AddMember(Person person)
    {
        members.Add(person);
    }
    public void ShowFamily()
    {
        for(int i = 0; i < members.Count; i++)
        {
            members[i].Show();
        }
    }
    public Person GetOldestMember ()
    {
        if (members.Count == 0)
        {
            return null;
        }
        int maxAge = members[0].Age;
        Person oldest = members[0];
        for(int i = 1; i < members.Count; i++)
        {
            if (members[i].Age > maxAge)
            {
                maxAge = members[i].Age;
                oldest = members[i];
            }
        }
        return oldest;

    }

}
public class Program
{
    public static void Main()
    {
        Family family = new Family();
        Console.WriteLine("Enter n of people;");
                int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age:");
            int age = int.Parse(Console.ReadLine());
            Person person = new Person(name, age);
            family.AddMember(person);
        }
        Person oldest = family.GetOldestMember();
        if (oldest != null)
        {
            Console.WriteLine("Oldest member:");
            oldest.Show();
        }
       

    }
}

