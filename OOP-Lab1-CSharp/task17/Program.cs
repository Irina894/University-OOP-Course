using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n (1-7): ");
        int n = int.Parse(Console.ReadLine());

        if (n > 7 || n < 1)
        {
            Console.WriteLine("not valid");
            return;
        }

        switch (n)
        {
            case 1:
                {
                    Console.WriteLine("Monday");
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Tuesday");
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Wednesday");
                    break;
                }
            case 4:
                {
                    Console.WriteLine("Thursday");
                    break;
                }
            case 5:
                {
                    Console.WriteLine("Friday");
                    break;
                }
            case 6:
                {
                    Console.WriteLine("Saturday");
                    break;
                }
            case 7:
                {
                    Console.WriteLine("Sunday");
                    break;
                }
            default:
                Console.WriteLine("not valid");
                break;
        }
    }
}