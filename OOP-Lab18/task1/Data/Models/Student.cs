using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            // Ініціалізуємо колекції, щоб уникнути NullReferenceException
            this.CourseEnrollments = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        // Unicode налаштування ми додатково підтвердимо у Fluent API, 
        // хоча string за замовчуванням є nvarchar (unicode)
        public string Name { get; set; }

        // Довжина 10, не unicode, не обов'язковий -> налаштуємо детально в DbContext
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        // Not required (Nullable DateTime)
        public DateTime? Birthday { get; set; }

        // Navigation Properties
        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}