using System;
class Program
    {
        static void Main()
        {
        Console.WriteLine("Enter k: ");
        int k=int .Parse(Console.ReadLine());
        int[] arr = new int[4 * k];

        Console.WriteLine("Enter elements of array:");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int[] first= new int[k];

        int[] last= new int[k];
        for (int i = 0; i < k; i++)
        {
            first[i] = arr[k - 1 - i]; 
       last[i] = arr[arr.Length - 1 - i];
        }
       
        int[] middle= new int[2*k];
        for (int i = 0; i < middle.Length; i++)
        {
            middle[i] = arr[k + i];
        }

        int[] upper = new int[2 * k];
        for (int i = 0; i < k; i++)
        {
            upper[i] = first[i];
            upper[i + k] = last[i];
        }

        int[] sum = new int[2 * k];
        for (int i = 0; i <sum.Length ; i++)
        {
            sum[i] = upper[i] + middle[i];
        }

        for (int i = 0; i < sum.Length; i++)
        {
            Console.Write(sum[i] + " ");
        }

    }
    }
