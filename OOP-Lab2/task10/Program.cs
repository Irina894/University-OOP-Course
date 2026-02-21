using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n for arr:");
        int n= int.Parse(Console.ReadLine());
        int[] arr= new int[n];
        Console.WriteLine("Enter elements for arr:");
        for (int i = 0; i < n; i++)
        {
            arr[i]=int.Parse(Console.ReadLine()) ;
        }
        Console.WriteLine("Enter difference: ");
        int difference = int.Parse(Console.ReadLine());

        int count = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if ((arr[i] - arr[j]) == difference)
                {
                    count++;
                }
                else if ()
            }
        }
        
        Console.WriteLine("Result: "+ count);
    }
}
