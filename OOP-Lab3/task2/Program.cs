using System;

class Person
{
    public string Name;
    public int Age;
 public Person(): this ("NoName",1)
    {
   
    }
    public Person(int Age) :this("NoName",Age)
    {

    }
    public Person (string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public void Show()
    {
        Console.WriteLine($"Name: {Name}  Age: {Age} ");
    }
}
public class Program
{
    public static void Main()
    {
        Person person = new Person();
        person.Show();
        Person person2 = new Person(25);
        person2.Show();
        Person person3 = new Person("Petro", 15);
        person3.Show();

    }
}

