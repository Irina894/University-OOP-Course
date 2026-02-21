using System;
using System.Collections.Generic;
using System.Collections;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private List<T> data;

    public CustomList()
    {
        this.data = new List<T>();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= this.data.Count)
        {
            throw new IndexOutOfRangeException();
        }
        T element = this.data[index];
        this.data.RemoveAt(index);
        return element;
    }

    public bool Contains(T element)
    {
        return this.data.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        if (index1 < 0 || index1 >= this.data.Count || index2 < 0 || index2 >= this.data.Count)
        {
            throw new IndexOutOfRangeException();
        }
        T temp = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        foreach (T item in this.data)
        {
            if (item.CompareTo(element) > 0)
            {
                count++;
            }
        }
        return count;
    }

    public T Max()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("Список порожній.");
        }
        T maxElement = this.data[0];
        for (int i = 1; i < this.data.Count; i++)
        {
            if (this.data[i].CompareTo(maxElement) > 0)
            {
                maxElement = this.data[i];
            }
        }
        return maxElement;
    }

    public T Min()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("Список порожній.");
        }
        T minElement = this.data[0];
        for (int i = 1; i < this.data.Count; i++)
        {
            if (this.data[i].CompareTo(minElement) < 0)
            {
                minElement = this.data[i];
            }
        }
        return minElement;
    }

    public void Print()
    {
        foreach (T item in this)
        {
            Console.WriteLine(item);
        }
    }

    public List<T> Data
    {
        get { return this.data; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public static class Sorter
{
    public static void Sort<T>(CustomList<T> customList) where T : IComparable<T>
    {
        customList.Data.Sort();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CustomList<string> customList = new CustomList<string>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] parts = command.Split(' ');
            string action = parts[0];

            switch (action)
            {
                case "Add":
                    customList.Add(parts[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(parts[1]));
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(parts[1]));
                    break;
                case "Swap":
                    customList.Swap(int.Parse(parts[1]), int.Parse(parts[2]));
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(parts[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Sort":
                    Sorter.Sort(customList);
                    break;
                case "Print":
                    customList.Print();
                    break;
            }
        }
    }
}