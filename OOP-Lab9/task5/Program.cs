using System;
using System.Linq;
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

        List<int> numbers = new List<int>();

        for (int i = 0; i < n; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }

        int[] swapIndexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int firstIndex = int.Parse(Console.ReadLine());
        int secondIndex = int.Parse(Console.ReadLine());
        SwapUtil.Swap(numbers, firstIndex, secondIndex);

        foreach (int item in numbers)
        {
            Box<int> box = new Box<int>(item);
            Console.WriteLine(box.ToString());
        }
    }
}