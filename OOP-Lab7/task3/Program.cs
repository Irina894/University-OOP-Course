using System;
using System.Collections.Generic;
using System.Globalization;

interface ISoldier
{
    int Id { get; }
    string FirstName { get; }
    string LastName { get; }
}

interface IPrivate : ISoldier
{
    double Salary { get; }
}

interface ILeutenantGeneral : ISoldier
{
    List<IPrivate> Privates { get; }
}

interface ISpecialisedSoldier : ISoldier
{
    string Corps { get; }
}

interface IEngineer : ISpecialisedSoldier
{
    List<IRepair> Repairs { get; }
}

interface ICommando : ISpecialisedSoldier
{
    List<IMission> Missions { get; }
}

interface ISpy : ISoldier
{
    int CodeNumber { get; }
}

interface IRepair
{
    string PartName { get; }
    int HoursWorked { get; }
}

interface IMission
{
    string CodeName { get; }
    string State { get; }
    void CompleteMission();
}

abstract class Soldier : ISoldier
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }

    protected Soldier(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}";
    }
}

class Private : Soldier, IPrivate
{
    public double Salary { get; }

    public Private(int id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {Salary:F2}";
    }
}

class LeutenantGeneral : Soldier, ILeutenantGeneral
{
    public double Salary { get; }
    public List<IPrivate> Privates { get; }

    public LeutenantGeneral(int id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName)
    {
        Salary = salary;
        Privates = new List<IPrivate>();
    }

    public override string ToString()
    {
        var privatesInfo = string.Join(Environment.NewLine + "  ", Privates);
        return base.ToString() + $" Salary: {Salary:F2}\nPrivates:\n  {privatesInfo}";
    }
}

abstract class SpecialisedSoldier : Soldier, ISpecialisedSoldier
{
    public string Corps { get; }

    protected SpecialisedSoldier(int id, string firstName, string lastName, string corps)
        : base(id, firstName, lastName)
    {
        if (corps != "Airforces" && corps != "Marines")
            throw new ArgumentException("Invalid corps");
        Corps = corps;
    }

    public override string ToString()
    {
        return base.ToString() + $" Corps: {Corps}";
    }
}

class Engineer : SpecialisedSoldier, IEngineer
{
    public List<IRepair> Repairs { get; }

    public Engineer(int id, string firstName, string lastName, string corps)
        : base(id, firstName, lastName, corps)
    {
        Repairs = new List<IRepair>();
    }

    public override string ToString()
    {
        var repairsInfo = string.Join(Environment.NewLine + "  ", Repairs);
        return base.ToString() + $"\nRepairs:\n  {repairsInfo}";
    }
}

class Commando : SpecialisedSoldier, ICommando
{
    public double Salary { get; }
    public List<IMission> Missions { get; }

    public Commando(int id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, corps)
    {
        Salary = salary;
        Missions = new List<IMission>();
    }

    public override string ToString()
    {
        var missionsInfo = string.Join(Environment.NewLine + "  ", Missions);
        return base.ToString() + $" Salary: {Salary:F2}\nCorps: {Corps}\nMissions:\n  {missionsInfo}";
    }
}

class Spy : Soldier, ISpy
{
    public int CodeNumber { get; }

    public Spy(int id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCode Number: {CodeNumber}";
    }
}

class Repair : IRepair
{
    public string PartName { get; }
    public int HoursWorked { get; }

    public Repair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public override string ToString() => $"Part Name: {PartName} Hours Worked: {HoursWorked}";
}

class Mission : IMission
{
    public string CodeName { get; }
    public string State { get; private set; }

    public Mission(string codeName, string state)
    {
        if (state != "inProgress" && state != "Finished")
            throw new ArgumentException("Invalid mission state");

        CodeName = codeName;
        State = state;
    }

    public void CompleteMission() => State = "Finished";

    public override string ToString() => $"Code Name: {CodeName} State: {State}";
}

class Program
{
    static void Main()
    {
        List<ISoldier> soldiers = new List<ISoldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split();
            string type = parts[0];

            switch (type)
            {
                case "Private":
                    int id = int.Parse(parts[1]);
                    string firstName = parts[2];
                    string lastName = parts[3];
                    double salary = double.Parse(parts[4], CultureInfo.InvariantCulture);
                    soldiers.Add(new Private(id, firstName, lastName, salary));
                    break;

                case "LeutenantGeneral":
                    id = int.Parse(parts[1]);
                    firstName = parts[2];
                    lastName = parts[3];
                    salary = double.Parse(parts[4], CultureInfo.InvariantCulture);

                    List<IPrivate> privates = new List<IPrivate>();
                    for (int i = 5; i < parts.Length; i++)
                    {
                        int privateId = int.Parse(parts[i]);
                        IPrivate subordinate = soldiers.Find(s => s.Id == privateId) as IPrivate;
                        if (subordinate != null)
                            privates.Add(subordinate);
                    }

                    var general = new LeutenantGeneral(id, firstName, lastName, salary);
                    general.Privates.AddRange(privates);
                    soldiers.Add(general);
                    break;

            }
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}
