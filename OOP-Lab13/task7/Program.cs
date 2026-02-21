using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> Grades { get; set; }

    public Student(string firstName, string lastName, List<int> grades)
    {
        FirstName = firstName;
        LastName = lastName;
        Grades = grades;
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

            string[] data = input.Split(' ');

            string firstName = data[0];
            string lastName = data[1];

            List<int> grades = data
                .Skip(2)
                .Select(int.Parse)
                .ToList();

            students.Add(new Student(firstName, lastName, grades));
        }

        var excellentStudents = students
            .Where(s => s.Grades.Contains(6))
            .Select(s => $"{s.FirstName} {s.LastName}");

        foreach (var student in excellentStudents)
        {
            Console.WriteLine(student);
        }
    }
}
