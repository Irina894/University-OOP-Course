using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string FacultyNumber { get; set; }
    public List<int> Grades { get; set; }

    public Student(string facNum, List<int> grades)
    {
        FacultyNumber = facNum;
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

            string facultyNumber = data[0];

            List<int> grades = data
                .Skip(1)
                .Select(int.Parse)
                .ToList();

            students.Add(new Student(facultyNumber, grades));
        }

        var selected = students
            .Where(s => s.FacultyNumber.Substring(4, 2) == "14" ||
                        s.FacultyNumber.Substring(4, 2) == "15")
            .Select(s => string.Join(" ", s.Grades));

        foreach (var grades in selected)
        {
            Console.WriteLine(grades);
        }
    }
}
