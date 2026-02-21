using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string wordsPath = @"D:\курс2\ООП\laba15\task3\words.txt";
        string textPath = @"D:\курс2\ООП\laba15\task3\text.txt";
        string actualPath = @"D:\курс2\ООП\laba15\task3\actualResult.txt";
        string expectedPath = @"D:\курс2\ООП\laba15\task3\expectedResult.txt";

            var words = File.ReadAllLines(wordsPath);
            var searchWords = new HashSet<string>();
            foreach (var w in words)
            {
                string cleanWord = w.Trim().ToLower();
                if (cleanWord.Length > 0)
                {
                    searchWords.Add(cleanWord);
                }
            }

            string text = File.ReadAllText(textPath).ToLower();
            char[] punctuation = { '.', ',', '-', '?', '!', ';', ':', '\n', '\r' };
            foreach (var c in punctuation)
                text = text.Replace(c.ToString(), " ");

            var textWords = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var w in searchWords)
            {
                result[w] = 0;
            }

            foreach (var tWord in textWords)
            {
                if (result.ContainsKey(tWord))
                {
                    result[tWord]++; 
                }
            }

            List<KeyValuePair<string, int>> outputList = new List<KeyValuePair<string, int>>(result);

            outputList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            List<string> outputLines = new List<string>();
            foreach (var pair in outputList)
            {
                outputLines.Add($"{pair.Key} - {pair.Value}");
            }

            File.WriteAllLines(actualPath, outputLines);

            if (File.Exists(expectedPath))
            {
                string expected = File.ReadAllText(expectedPath).Trim();
                string actual = File.ReadAllText(actualPath).Trim();

                if (expected == actual)
                    Console.WriteLine("Результат правильний");
                else
                    Console.WriteLine("Результат НЕ збігається");
            }

            Console.WriteLine("Готово!");
        }
    }

