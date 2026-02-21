using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n for arr:");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter elements of array:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int start = 0;
        int len = 1;

        int bestStart = 0;
        int bestLen = 1;

        for (int pos = 1; pos < arr.Length; pos++)
        {
            if (arr[pos] == arr[pos - 1])
            {
                len++;
            }
            else
            {
                start = pos;
                len = 1;
            }

            if (len > bestLen) 
            {
                bestLen = len;
                bestStart = start;
            }
        }

        for (int i = 0; i < bestLen; i++)
        {
            Console.Write(arr[bestStart + i] + " ");
        }
    }
}
