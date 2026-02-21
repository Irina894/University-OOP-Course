using System;
using System.Collections.Generic;
using System.Linq;
public class Box<T> : IComparable<Box<T>>
    where T : IComparable<T> 
{
    private T Value { get; set; }

    public Box(T value)
    {
        this.Value = value;
    }

    public int CompareTo(Box<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }

    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value.ToString()}";
    }

    public T GetValue()
    {
        return this.Value;
    }
}
public static class CountUtil
{
    public static int CountGreaterThan<T>(List<T> list, T elementToCompare)
        where T : IComparable<T> 
    {
        int count = 0;

        foreach (T item in list)
        {
            if (item.CompareTo(elementToCompare) > 0)
            {
                count++;
            }
        }
        return count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            return;
        }
        List<string> elements = new List<string>();

        for (int i = 0; i < n; i++)
        {
            elements.Add(Console.ReadLine());
        }
        string elementToCompare = Console.ReadLine();

        int greaterElementsCount = CountUtil.CountGreaterThan(elements, elementToCompare);

        Console.WriteLine(greaterElementsCount);
    }
}