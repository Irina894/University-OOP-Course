using System;
using System.Collections.Generic;

class Employee
{
    public string Name;
    public double Salary;
    public string Position;
    public string Department;
    public string Email;
    public int Age;

    public Employee(string name, double salary, string position, string department)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = "n/a"; 
        this.Age = -1;   
    }

    public Employee(string name, double salary, string position, string department, string email, int age)
        : this(name, salary, position, department)
    {
        this.Email = email;
        this.Age = age;
    }

    public void Show()
    {
        Console.WriteLine($"{Name} {Salary:F2} {Email} {Age}");
    }
}

class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter n of employees:");
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter salary:");
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter position:");
            string position = Console.ReadLine();

            Console.WriteLine("Enter department:");
            string department = Console.ReadLine();

            Console.WriteLine("Do you want to enter email? (y/n)");
            string answerEmail = Console.ReadLine();
            string email = "n/a";
            if (answerEmail.ToLower() == "y")
            {
                Console.WriteLine("Enter email:");
                email = Console.ReadLine();
            }

            Console.WriteLine("Do you want to enter age? (y/n)");
            string answerAge = Console.ReadLine();
            int age = -1;
            if (answerAge.ToLower() == "y")
            {
                Console.WriteLine("Enter age:");
                age = int.Parse(Console.ReadLine());
            }

            employees.Add(new Employee(name, salary, position, department, email, age));
           
        }

        for (int i = 0; i <n; i++)
        {
            employees[i].Show();
        }

        List<string> departments = new List<string>();
       for(int i=0; i<employees.Count; i++)
        {
            if (!departments.Contains(employees[i].Department))
            {
                departments.Add(employees[i].Department);
            }
        }
     
        string bestDepartment = "";
        double bestAverage = 0;

        for (int i=0; i<departments.Count; i++)
        {  
            string dept = departments[i];
            double totalSalary = 0;
            int count = 0;
            for (int j = 0; j < employees.Count; j++)
            {
                if (employees[j].Department == dept)
                {
                    totalSalary += employees[j].Salary;
                    count++;
                }
            }
            double averageSalary = totalSalary / count;
            if (averageSalary > bestAverage)
            {
                bestAverage = averageSalary;
                bestDepartment = dept;
            }
        }
       
        Console.WriteLine("Highest Average Salary: " + bestDepartment);

        for (int i = 0; i < employees.Count - 1; i++)
        {
            for (int j = i + 1; j < employees.Count; j++)
            {
                if (employees[i].Salary < employees[j].Salary)
                {
                    Employee temp = employees[i];
                    employees[i] = employees[j];
                    employees[j] = temp;
                }
            }
        }

        for (int i = 0; i < employees.Count; i++)
        {
            if (employees[i].Department == bestDepartment)
            {
                employees[i].Show();
            }
        }
    }
}
