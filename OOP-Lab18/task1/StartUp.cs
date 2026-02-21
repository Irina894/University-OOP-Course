using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;
using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // 1. Налаштування консолі для коректного відображення кирилиці (української мови)
            Console.OutputEncoding = Encoding.UTF8;

            // 2. Створення підключення до бази даних
            using (var context = new StudentSystemContext())
            {
                // Створюємо базу даних, якщо вона ще не існує
                // (Якщо база вже є, цей метод нічого не змінить)
                context.Database.EnsureCreated();
                Console.WriteLine("--- Статус БД: Перевірку завершено ---");

                // 3. Виклик методу Seed (Завдання: Заповнення даними)
                SeedDatabase(context);

                // 4. Виклик методу Read (Завдання: Зчитування інформації)
                ReadData(context);
            }
        }

        // --- МЕТОД 1: НАПОВНЕННЯ БАЗИ (SEED) ---
        private static void SeedDatabase(StudentSystemContext context)
        {
            // Перевірка: Якщо в базі вже є студенти, ми не додаємо дублікати
            if (context.Students.Any())
            {
                Console.WriteLine("\n[Info] База даних вже містить записи. Seed пропущено.");
                return;
            }

            Console.WriteLine("\n[Info] База даних порожня. Починаємо наповнення...");

            // Крок 1: Створення студентів
            var student1 = new Student
            {
                Name = "Олександр Ткаченко",
                PhoneNumber = "0951234567",
                RegisteredOn = DateTime.Now.AddMonths(-6),
                Birthday = new DateTime(2001, 4, 15)
            };

            var student2 = new Student
            {
                Name = "Марія Яковенко",
                PhoneNumber = "0639876543",
                RegisteredOn = DateTime.Now.AddMonths(-2),
                Birthday = new DateTime(2000, 10, 20)
            };

            var student3 = new Student
            {
                Name = "Дмитро Бондар",
                RegisteredOn = DateTime.Now.AddDays(-10) // Без телефону та дня народження
            };

            context.Students.AddRange(student1, student2, student3);

            // Крок 2: Створення курсів
            var courseCSharp = new Course
            {
                Name = "C# Advanced",
                Description = "Поглиблене вивчення мови C# та .NET",
                StartDate = DateTime.Now.AddDays(-20),
                EndDate = DateTime.Now.AddMonths(2),
                Price = 2500
            };

            var courseDb = new Course
            {
                Name = "Database Basics",
                Description = "Вступ до SQL Server та EF Core",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                Price = 1800
            };

            context.Courses.AddRange(courseCSharp, courseDb);

            // Крок 3: Створення ресурсів (прив'язуємо до курсів)
            var resources = new List<Resource>
            {
                new Resource { Name = "Відео: Делегати", Url = "https://youtube.com/video1", ResourceType = ResourceType.Video, Course = courseCSharp },
                new Resource { Name = "Слайди: LINQ", Url = "https://slides.com/linq", ResourceType = ResourceType.Presentation, Course = courseCSharp },
                new Resource { Name = "Документація SQL", Url = "https://microsoft.com/sql", ResourceType = ResourceType.Document, Course = courseDb },
                new Resource { Name = "Приклади коду", Url = "https://github.com/examples", ResourceType = ResourceType.Other, Course = courseDb }
            };
            context.Resources.AddRange(resources);

            // Крок 4: Запис студентів на курси (StudentCourse)
            // Олександр вчить C# і Бази даних
            context.StudentCourses.Add(new StudentCourse { Student = student1, Course = courseCSharp });
            context.StudentCourses.Add(new StudentCourse { Student = student1, Course = courseDb });

            // Марія вчить тільки Бази даних
            context.StudentCourses.Add(new StudentCourse { Student = student2, Course = courseDb });

            // Дмитро вчить C#
            context.StudentCourses.Add(new StudentCourse { Student = student3, Course = courseCSharp });

            // Крок 5: Створення домашніх завдань
            var homeworks = new List<Homework>
            {
                new Homework { Content = "Delegates_Task.zip", ContentType = ContentType.Zip, SubmissionTime = DateTime.Now.AddDays(-5), Student = student1, Course = courseCSharp },
                new Homework { Content = "SQL_Queries.pdf", ContentType = ContentType.Pdf, SubmissionTime = DateTime.Now, Student = student1, Course = courseDb },
                new Homework { Content = "Database_Design.pdf", ContentType = ContentType.Pdf, SubmissionTime = DateTime.Now.AddHours(-2), Student = student2, Course = courseDb }
            };
            context.HomeworkSubmissions.AddRange(homeworks);

            // Крок 6: Збереження всіх змін у базу (Commit Transaction)
            context.SaveChanges();
            Console.WriteLine("[Success] Дані успішно додано до бази!");
        }

        // --- МЕТОД 2: ЗЧИТУВАННЯ ДАНИХ (READ) ---
        private static void ReadData(StudentSystemContext context)
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("    ЗВІТ ПО БАЗІ ДАНИХ");
            Console.WriteLine("=================================");

            Console.WriteLine("\n>>> АКТИВНІ КУРСИ ТА РЕСУРСИ:");
            var courses = context.Courses
                .Include(c => c.Resources)
                .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"\nКурс: {course.Name}");
                Console.WriteLine($"  |-- Опис: {course.Description}");
                Console.WriteLine($"  |-- Ціна: {course.Price} грн");
                Console.WriteLine($"  |-- Кількість ресурсів: {course.Resources.Count}");

                foreach (var res in course.Resources)
                {
                    Console.WriteLine($"      * [{res.ResourceType}] {res.Name} ({res.Url})");
                }
            }
            Console.WriteLine("\n\n>>> СТУДЕНТИ ТА ДОМАШНІ ЗАВДАННЯ:");

            var students = context.Students
                .Include(s => s.HomeworkSubmissions)
                .ThenInclude(h => h.Course)
                .ToList();

            foreach (var student in students)
            {
                Console.WriteLine($"\nСтудент: {student.Name}");
                Console.WriteLine($"  |-- Телефон: {(student.PhoneNumber ?? "Не вказано")}");

                if (student.HomeworkSubmissions.Count == 0)
                {
                    Console.WriteLine("  |-- Немає зданих робіт.");
                }
                else
                {
                    Console.WriteLine($"  |-- Здані роботи ({student.HomeworkSubmissions.Count}):");
                    foreach (var hw in student.HomeworkSubmissions)
                    {
                        Console.WriteLine($"      * Курс: '{hw.Course.Name}' | Файл: {hw.Content} | Час: {hw.SubmissionTime.ToShortDateString()}");
                    }
                }
            }
            Console.WriteLine("\n=================================");
        }
    }
}