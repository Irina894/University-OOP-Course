using System;
using System.Collections.Generic;

public class Box<T>
{
    private T Value { get; set; }
    public Box(T value) { this.Value = value; }
    public override string ToString()
    {
        return $"{this.Value.GetType().FullName}: {this.Value.ToString()}";
    }
}

public class SwapUtil
{
    public static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
    {
        T temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> strings = new List<string>();
        for (int i = 0; i < n; i++)
        {
            strings.Add(Console.ReadLine());
        }

        int firstIndex = int.Parse(Console.ReadLine());

        int secondIndex = int.Parse(Console.ReadLine());
    
        SwapUtil.Swap(strings, firstIndex, secondIndex);

        foreach (string item in strings)
        {
            Box<string> box = new Box<string>(item);
            Console.WriteLine(box.ToString());
        }
    }
}