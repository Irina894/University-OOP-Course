using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            string[] parts = input.Split(' ');
            string firstName = parts[0];
            string lastName = parts[1];

            students.Add(new Student(firstName, lastName));
        }

        var result =
            from s in students
            where s.FirstName.CompareTo(s.LastName) < 0
            select s;

        foreach (var student in result)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}

