using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> elements;
    private int currentIndex;

    public ListyIterator(IEnumerable<T> collection)
    {
        if (collection != null)
        {
            this.elements = collection.ToList();
        }
        else
        {
            this.elements = new List<T>();
        }

        this.currentIndex = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            yield return elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public bool Move()
    {
        if (HasNext())
        {
            currentIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return currentIndex < elements.Count - 1;
    }

    public void Print()
    {
        if (!elements.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(elements[currentIndex]);
    }
}

public class Program
{
    public static void Main()
    {
        ListyIterator<string> listyIterator = null;

        string commandLine;
        while ((commandLine = Console.ReadLine()) != "END")
        {
            string[] parts = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        List<string> elements = parts.Skip(1).ToList();
                        listyIterator = new ListyIterator<string>(elements);
                        break;

                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;

                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;

                    case "Print":
                        listyIterator.Print();
                        break;

                    case "PrintAll":
                        string result = string.Join(" ", listyIterator);
                        Console.WriteLine(result);
                        break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}