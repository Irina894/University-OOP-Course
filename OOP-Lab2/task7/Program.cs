
using System;
public class Program    
{
    public static void Main()
    {

        Console.WriteLine("Enter n for arr:");
  int n=int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter elements of array:");  
        for (int i = 0; i <n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        if (arr == null || arr.Length == 0)
        {
            Console.WriteLine("Array is empty.");
            return;
        }

        int bestLength = 1;
        int length = 1;
        int start = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] >arr[i - 1])
            {
                length++;
            }
            else
            {
                start= i;
                length = 1;
            }

            if (length > bestLength)
            {
                bestLength =length;
                start = i - length + 1;
            }
        }

        for (int i = 0; i < bestLength; i++)
        {
            Console.Write(arr[start + i] + " ");
        }
        Console.WriteLine();
    }

   
}