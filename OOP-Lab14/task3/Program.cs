using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        Func<int[], int> findMin = nums => nums.Min();
        Console.WriteLine(findMin(numbers));
    }
}
