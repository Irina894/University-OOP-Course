using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Student(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
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
            int age = int.Parse(parts[2]);

            students.Add(new Student(firstName, lastName, age));
        }

        var result =
            from s in students
            where s.Age >= 18 && s.Age <= 24
            select s;

        foreach (var student in result)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}");
        }
    }
}

