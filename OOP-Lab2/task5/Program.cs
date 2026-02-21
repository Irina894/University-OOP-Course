using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first array :");
        string[] arr1 = Console.ReadLine().Split(' ');

        Console.WriteLine("Enter second array:");
        string[] arr2 = Console.ReadLine().Split(' ');

        string first = string.Join("", arr1);
        string second = string.Join("", arr2);

        int minLength = Math.Min(first.Length, second.Length);
        bool difference= false;

        for (int i = 0; i < minLength; i++)
        {
            if (first[i] < second[i])
            {
                Console.WriteLine(first);
                Console.WriteLine(second);
                difference= true;
                break;
            }
            else if (first[i] > second[i])
            {
                Console.WriteLine(second);
                Console.WriteLine(first);
                difference = true;
                break;
            }
        }

        if (!difference)
        {
            if (first.Length < second.Length)
            {
                Console.WriteLine(first);
                Console.WriteLine(second);
            }
            else if (first.Length > second.Length)
            {
                Console.WriteLine(second);
                Console.WriteLine(first);
            }
            else 
            {
                Console.WriteLine(first);
                Console.WriteLine(second);
            }
        }
    }
}
