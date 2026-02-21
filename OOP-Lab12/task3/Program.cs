using System;
using System.Collections;
using System.Collections.Generic;
interface IEmployee
{
    string Name { get; }
    int WorkHoursPerWeek { get; }
}

class StandardEmployee : IEmployee
{
    public string Name { get; private set; }
    public int WorkHoursPerWeek { get { return 40; } }

    public StandardEmployee(string name)
    {
        Name = name;
    }
}

class PartTimeEmployee : IEmployee
{
    public string Name { get; private set; }
    public int WorkHoursPerWeek { get { return 20; } }

    public PartTimeEmployee(string name)
    {
        Name = name;
    }
}

class Job
{
    public string Name { get; private set; }
    public int HoursRequired { get; private set; }
    private IEmployee employee;

    public event EventHandler JobDone;

    public Job(string name, int hoursRequired, IEmployee employee)
    {
        Name = name;
        HoursRequired = hoursRequired;
        this.employee = employee;
    }

    public void Update()
    {
        HoursRequired -= employee.WorkHoursPerWeek;

        if (HoursRequired <= 0)
        {
            Console.WriteLine("Job " + Name + " done!");
            if (JobDone != null)
                JobDone(this, EventArgs.Empty);
        }
    }
    public void Status()
    {
        if (HoursRequired > 0)
            Console.WriteLine("Job: " + Name + " Hours Remaining: " + HoursRequired);
    }
}

class JobList
{
    private List<Job> jobs = new List<Job>();

    public void AddJob(Job job)
    {
        jobs.Add(job);
        job.JobDone += OnJobDone;
    }

    private void OnJobDone(object sender, EventArgs e)
    {
        Job doneJob = sender as Job;
        if (doneJob != null)
        {
            jobs.Remove(doneJob);
        }
    }

    public void UpdateAll()
    {
        List<Job> copy = new List<Job>(jobs);
        foreach (var job in copy)
        {
            job.Update();
        }
    }

    public void StatusAll()
    {
        foreach (var job in jobs)
        {
            job.Status();
        }
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, IEmployee> employees = new Dictionary<string, IEmployee>();
        JobList jobList = new JobList();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] parts = input.Split(' ');

            if (parts[0] == "StandardEmployee")
            {
                employees[parts[1]] = new StandardEmployee(parts[1]);
            }
            else if (parts[0] == "PartTimeEmployee")
            {
                employees[parts[1]] = new PartTimeEmployee(parts[1]);
            }
            else if (parts[0] == "Job")
            {
                string jobName = parts[1];
                int hours = int.Parse(parts[2]);
                string employeeName = parts[3];

                IEmployee emp = employees[employeeName];
                Job job = new Job(jobName, hours, emp);
                jobList.AddJob(job);
            }
            else if (parts[0] == "Pass" && parts[1] == "Week")
            {
                jobList.UpdateAll();
            }
            else if (parts[0] == "Status")
            {
                jobList.StatusAll();
            }

            input = Console.ReadLine();
        }
    }
}
