using System;
using System.Collections.Generic;
using System.Linq;

class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public string FacultyNumber { get; set; }

    public StudentSpecialty(string specialty, string facNum)
    {
        SpecialtyName = specialty;
        FacultyNumber = facNum;
    }
}

class Student
{
    public string FacultyNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Student(string facNum, string first, string last)
    {
        FacultyNumber = facNum;
        FirstName = first;
        LastName = last;
    }
}

class ResultRecord
{
    public string FullName { get; set; }
    public string FacultyNumber { get; set; }
    public string Specialty { get; set; }

    public ResultRecord(string fullName, string facNum, string specialty)
    {
        FullName = fullName;
        FacultyNumber = facNum;
        Specialty = specialty;
    }
}

class Program
{
    static void Main()
    {
        List<StudentSpecialty> specialties = new List<StudentSpecialty>();
        List<Student> students = new List<Student>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Students:") break;

            string[] parts = input.Split(' ');
            string specialty = parts[0] + " " + parts[1];
            string facNum = parts[2];

            specialties.Add(new StudentSpecialty(specialty, facNum));
        }

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END") break;

            string[] parts = input.Split(' ');
            string facNum = parts[0];
            string firstName = parts[1];
            string lastName = parts[2];

            students.Add(new Student(facNum, firstName, lastName));
        }
        var joinedData =
            from st in students
            join sp in specialties on st.FacultyNumber equals sp.FacultyNumber
            orderby st.FirstName, st.LastName  
            select new ResultRecord(
                st.FirstName + " " + st.LastName,
                st.FacultyNumber,
                sp.SpecialtyName
            );
        foreach (var item in joinedData)
        {
            Console.WriteLine($"{item.FullName} {item.FacultyNumber} {item.Specialty}");
        }
    }
}
