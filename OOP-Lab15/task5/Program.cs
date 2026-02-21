using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string inputDirectory = Directory.GetCurrentDirectory();

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        string reportFilePath = Path.Combine(desktopPath, "report.txt");

        Console.WriteLine($"Пошук файлів у каталозі: {inputDirectory}");

        string[] allFiles;
        try
        {
            allFiles = Directory.GetFiles(inputDirectory);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Помилка доступу до каталогу: {ex.Message}");
            return;
        }

        var fileGroups = allFiles
            .Select(filePath => new FileInfo(filePath))
         
            .GroupBy(file => file.Extension.ToLower().Substring(file.Extension.ToLower().TrimStart('.').Length > 0 ? 1 : 0))
          
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key)
            .ToList();

        List<string> reportLines = new List<string>();

        foreach (var group in fileGroups)
        {
            string extension = group.Key.Length > 0 ? "." + group.Key : "(Без розширення)";

            reportLines.Add(extension);

            var sortedFiles = group
                .OrderBy(file => file.Length)
                .ToList();

            foreach (var file in sortedFiles)
            {
                double sizeKb = file.Length / 1024.0;
                string formattedSize = sizeKb.ToString("F3") + "kb";
                reportLines.Add($"--{file.Name} - {formattedSize}");
            }
        }

        try
        {
            File.WriteAllLines(reportFilePath, reportLines);
            Console.WriteLine($"\nЗвіт успішно збережено на Робочому столі: {reportFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nПомилка запису файлу: {ex.Message}");
        }
    }
}