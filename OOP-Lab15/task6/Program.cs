using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        string workingDirectory = Directory.GetCurrentDirectory();

        string sourceDir = Path.Combine(workingDirectory, "SourceFiles");
        string archiveDir = Path.Combine(workingDirectory, "Archives");
        string extractDir = Path.Combine(workingDirectory, "ExtractedFiles");

        string fileName = "copyMe.png";
        string filePath = Path.Combine(sourceDir, fileName);

        Directory.CreateDirectory(sourceDir);
        Directory.CreateDirectory(archiveDir);
        Directory.CreateDirectory(extractDir);

        Console.WriteLine($"Початок роботи. Очікуємо файл '{fileName}' у папці: {sourceDir}");

        string zipFileName = "MyArchive.zip";
        string zipFilePath = Path.Combine(archiveDir, zipFileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"\nПомилка: Вхідний файл '{fileName}' не знайдено за шляхом: {filePath}");
            Console.WriteLine("Будь ласка, помістіть його у вказану папку і спробуйте знову.");
            return;
        }

        try
        {
            ZipFile.CreateFromDirectory(sourceDir, zipFilePath, CompressionLevel.Fastest, false);
            Console.WriteLine($"\nАрхівація: Файл '{zipFileName}' успішно створено у {archiveDir}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка архівації: {ex.Message}");
            return;
        }

        try
        {
            if (Directory.Exists(extractDir))
            {
                Directory.Delete(extractDir, true);
                Directory.CreateDirectory(extractDir);
            }

            ZipFile.ExtractToDirectory(zipFilePath, extractDir);
            Console.WriteLine($"\nРозархівація: Вміст архіву розпаковано у {extractDir}");

            if (File.Exists(Path.Combine(extractDir, fileName)))
            {
                Console.WriteLine("\nПеревірка: Файл успішно скопійовано та розпаковано!");
            }
            else
            {
                Console.WriteLine("\nПеревірка: Файл не знайдено після розпакування.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка розархівації: {ex.Message}");
        }
    }
}