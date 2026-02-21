using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }

    public Student(string firstName, string lastName, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
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
            string phone = data[2];

            students.Add(new Student(firstName, lastName, phone));
        }

        var result = students
            .Where(s => s.Phone.EndsWith ("2"))
            .Select(s => $"{s.FirstName} {s.LastName}");

        foreach (var student in result)
        {
            Console.WriteLine(student);
        }
    }
}
