using System;

class Program
  {
        static void Main()
        {
        Console.WriteLine("Enter a first sentence:");
        string sentence1 = Console.ReadLine();

        string[] words1 = sentence1.Split(' ');
        Console.WriteLine("First sentence:");
        for (int i = 0; i < words1.Length; i++)
        {
               Console.Write(words1[i]+' ');
           
        }

        Console.WriteLine("Enter a second sentence:");
        string sentence2 = Console.ReadLine();

        string[] words2 = sentence2.Split(' ');
        Console.WriteLine("Second sentence:");
        for (int i = 0; i < words2.Length; i++)
        {
            Console.Write(words2[i]+' ');

        }

        int count = 0;
                for (int i = 0; i < words1.Length; i++) 
                {
                        if (words1[i] == words2[i])
                        {
                            count++;
                        }
                else
                    {
                break;
            }
            
        }

        int count2 = 0;
                for (int i = words1.Length-1; i >=0; i--) 
                {
                        if (words2[words2.Length-i-1] == words1[words1.Length-i-1])
                        {
                            count2++;
                        }
                else
                {
                    break;
                }
                    }

            if (count == 0 && count2 == 0)
                    {
                        Console.WriteLine("There are no common words on the left and right");
                    }
            else if (count>count2)
            {
                Console.WriteLine($"The largest common end on the left");
            }
            else
            {
                Console.WriteLine("The largest common end on the right.");
            }
        }


    }
    

