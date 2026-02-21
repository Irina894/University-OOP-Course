using System;
using System.Linq; 

interface ICallable
{
    string Call(string number);
}

interface IBrowsable
{
    string Browse(string site);
}

class Smartphone : ICallable, IBrowsable
{
    public string Call(string number)
    {
        if (!number.All(char.IsDigit))
        {
            throw new ArgumentException("Invalid number!");
        }

        return "Calling... " + number;
    }

    public string Browse(string site)
    {
        if (site.Any(char.IsDigit))
        {
            throw new ArgumentException("Invalid URL!");
        }

        return "Revision: " + site;
    }
}

class Program
{
    static void Main()
    {
        string[] numbers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string[] sites = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Smartphone phone = new Smartphone();

        foreach (var num in numbers)
        {
            try
            {
                Console.WriteLine(phone.Call(num));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var site in sites)
        {
            try
            {
                Console.WriteLine(phone.Browse(site));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
