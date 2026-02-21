using System;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
        {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            if (value.Length<4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            this.lastName = value;
        }
    }
}

public class Student : Human
{
    private string facultyNumber;
    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }
    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }
    public override string ToString()
    {
        return $"First Name: {this.FirstName}{Environment.NewLine}" +
            $"Last Name: {this.LastName}{Environment.NewLine}" +
            $"Faculty number: {this.FacultyNumber}";
    }
}

public class Worker : Human
{
    private decimal weekSalary;
    private double workHoursPerDay;
    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }
    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }
    public double WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }
    public double SalaryPerHour()
    {
        double hoursPerWeek = this.WorkHoursPerDay * 5;
      return (double)this.WeekSalary / hoursPerWeek;
    }
    public override string ToString()
    {
        return $"First Name: {this.FirstName}{Environment.NewLine}" +
            $"Last Name: {this.LastName}{Environment.NewLine}" +
            $"Week Salary: {this.WeekSalary:f2}{Environment.NewLine}" +
            $"Hours per day: {this.WorkHoursPerDay:f2}{Environment.NewLine}" +
            $"Salary per hour: {this.SalaryPerHour():f2}";
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string[] studentInfo = Console.ReadLine().Split();
            string[] workerInfo = Console.ReadLine().Split();
            Student student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);
            Worker worker = new Worker(workerInfo[0], workerInfo[1], decimal.Parse(workerInfo[2]), double.Parse(workerInfo[3]));
            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
