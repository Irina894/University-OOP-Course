using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputPath = "D://курс2//ООП//laba15//task2//text.txt";
        string outputPath = "D://курс2//ООП//laba15//task2//output.txt";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Файл text.txt не знайдено!");
                return;
            }
            string[] rawLines = File.ReadAllLines(inputPath);

            List<string> logicalLines = new List<string>();
            string current = "";

            foreach (var line in rawLines)
            {
                if (line.StartsWith("-"))
                {
                    if (current != "")
                        logicalLines.Add(current.Trim());

                    current = line;
                }
                else
                {
                    current += " " + line.Trim();
                }
            }
            if (current != "")
                logicalLines.Add(current.Trim());

            string[] result = new string[logicalLines.Count];

            for (int i = 0; i < logicalLines.Count; i++)
            {
                string line = logicalLines[i];

                int letterCount = line.Count(char.IsLetter);
                char[] punctuation = { '.', ',', '-', '?', '!', ';', ':' };
                int punctCount = line.Count(ch => punctuation.Contains(ch));

                result[i] = $"Line {i + 1}: {line} ({letterCount})({punctCount})";
            }
            File.WriteAllLines(outputPath, result);

            Console.WriteLine("Готово! Результат записано у output.txt");
        }
    }


