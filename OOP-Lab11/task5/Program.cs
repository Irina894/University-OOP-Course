using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
public class CustomClassAttribute : Attribute
{
    public string Author { get; }
    public int Revision { get; }
    public string Description { get; }
    public string[] Reviewers { get; }

    public CustomClassAttribute(string author, int revision, string description, params string[] reviewers)
    {
        Author = author;
        Revision = revision;
        Description = description;
        Reviewers = reviewers;
    }
}

[CustomClass(
    "Pesho",
    3,
    "Used for C# OOP Advanced Course - Enumerations and Attributes",
    "Pesho", "Svetlio")]
public class Weapon
{
    public string Name { get; set; }

    public Weapon(string name)
    {
        Name = name;
    }
}
class Program
{
    static void Main()
    {
        string input;
        Type weaponType = typeof(Weapon);

        var attr = weaponType.GetCustomAttribute<CustomClassAttribute>();

        while ((input = Console.ReadLine()) != "END")
        {
            switch (input)
            {
                case "Author":
                    Console.WriteLine($"Author: {attr.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {attr.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {attr.Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attr.Reviewers)}");
                    break;
            }
        }
    }
}
