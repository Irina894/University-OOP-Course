using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        // Конструктор за замовчуванням
        public StudentSystemContext()
        {
        }

        // Конструктор для ін'єкції опцій (наприклад, при тестуванні)
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        // DbSets - таблиці в базі даних
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        // Налаштування підключення до БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Замініть рядок підключення на ваш власний (наприклад, для MS SQL Server)
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Student_laba18;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        // Налаштування схеми БД за допомогою Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Налаштування сутності Student
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(s => s.Name)
                    .HasMaxLength(100)
                    .IsUnicode(true) // Явно вказуємо Unicode
                    .IsRequired();

                entity.Property(s => s.PhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength() // exactly 10 chars (CHAR(10))
                    .IsUnicode(false) // not unicode (VARCHAR)
                    .IsRequired(false); // not required

                entity.Property(s => s.Birthday)
                    .IsRequired(false);
            });

            // Налаштування сутності Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity.Property(c => c.Name)
                    .HasMaxLength(80)
                    .IsUnicode(true)
                    .IsRequired();

                entity.Property(c => c.Description)
                    .IsUnicode(true)
                    .IsRequired(false);
            });

            // Налаштування сутності Resource
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity.Property(r => r.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired();

                entity.Property(r => r.Url)
                    .IsUnicode(false) // not unicode
                    .IsRequired();
            });

            // Налаштування сутності Homework
            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity.Property(h => h.Content)
                    .IsUnicode(false) // not unicode
                    .IsRequired();
            });

            // Налаштування сутності StudentCourse (Mapping Table)
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                // Складений первинний ключ (Composite Key)
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                // Зв'язок Student -> StudentCourses
                entity.HasOne(sc => sc.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId);

                // Зв'язок Course -> StudentCourses
                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}