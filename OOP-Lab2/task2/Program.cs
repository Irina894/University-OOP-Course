using System;
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

        Console.WriteLine("Enter number of rotations:");
        int rotations=int.Parse(Console.ReadLine());
        
        int[] sum =new int[arr.Length];

        for (int i = 0; i < rotations; i++)
        {
            int last=arr[arr.Length-1];
            for (int j = arr.Length-1; j >0; j--)
            {
                arr[j]=arr[j-1];
            }
            arr[0]=last;

            for (int k = 0; k < arr.Length; k++)
            {
                sum[k]+=arr[k];
            }
        }

        Console.WriteLine("Array after rotations:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(sum[i] +" ");
        }
    }
    }
