using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter size for primes: ");
        int n = int.Parse(Console.ReadLine());

        bool[] primes = new bool[n + 1];

        for (int i = 0; i <= n; i++)
        {
            primes[i] = true;
        }

        primes[0] = false;
        primes[1] = false;

        for (int i = 2; i * i <= n; i++)
        {
            if (primes[i])
            {
                for (int j = i * 2; j <= n; j += i)
                {
                    primes[j] = false;
                }
            }
          
        }

        Console.WriteLine("Prime numbers up to " + n + ":");
        for (int i = 2; i <= n; i++)
        {
            if (primes[i])
            {
                Console.Write(i + " ");
            }
        }
    }

}
    

