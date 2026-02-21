using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("Enter numbers: ");
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int maxCount = 0;
        List<int> meetNum = new List<int>(); 
   
        for (int i = 0; i < n; i++)
        {
            int count = 0; 
            for (int j = 0; j < n; j++)
            {
                if (numbers[j] == numbers[i])
                {
                    count++;
                }
            }
          
            if (count > maxCount)
            {
                maxCount = count; 
                meetNum.Clear(); 
                meetNum.Add(numbers[i]); 
            }
            else if (count == maxCount && !meetNum.Contains(numbers[i]))
            {
                meetNum.Add(numbers[i]);
            }
        }
        int leftMost = -1;
        for (int i = 0; i < n; i++)
        {
            for (int k = 0; k < meetNum.Count; k++)
            {
                if (numbers[i] == meetNum[k])
                {
                    leftMost = numbers[i]; 
                    break;
                }
            }
            if (leftMost != -1) break; 
        }
        Console.WriteLine($"Number {string.Join(", ", meetNum)} occurs most frequently ({maxCount} times)");
        Console.WriteLine($"Leftmost number – {leftMost}");
    }
}