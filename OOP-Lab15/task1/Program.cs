using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "D://курс2//ООП//laba15/task1/text.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл '{filePath}' не знайдено.");
            return;
        }

        using (var reader = new StreamReader(filePath))
        {
            int lineIndex = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    lineIndex++;
                    continue;
                }

                if (lineIndex % 2 == 0)
                {
                    char[] toReplace = new char[] { '-', ',', '.', '!', '?' };
                    foreach (var ch in toReplace)
                    {
                        line = line.Replace(ch, '@');
                    }

                    var words = line.Split(
                        new char[] { ' ', '\t' },
                        StringSplitOptions.RemoveEmptyEntries
                    );

                    Array.Reverse(words);

                    string output = string.Join(" ", words);

                    Console.WriteLine(output);
                }

                lineIndex++;
            }
        }
    }
}
