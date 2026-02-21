using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFilePath = "D://курс2//ООП//laba15/task4//source_file.jpg"; 
        string destinationFilePath = "D://курс2//ООП//laba15//task4//copy_of_source_file.jpg";

        const int bufferSize = 4096;

        Console.WriteLine($"Початок копіювання: {sourceFilePath} -> {destinationFilePath}");

        try
        {
            using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead; 

                while ((bytesRead = sourceStream.Read(buffer, 0, bufferSize)) > 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                }

                Console.WriteLine("Копіювання успішно завершено! ✔");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Помилка: Вхідний файл '{sourceFilePath}' не знайдено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Виникла помилка під час копіювання: {ex.Message}");
        }
        Console.WriteLine("Програма завершила роботу.");
    }
}