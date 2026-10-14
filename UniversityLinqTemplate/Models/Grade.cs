using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityLinqTemplate.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int Score { get; set; } // Оценка: от 2 до 5 или баллы 0-100
        public DateTime Date { get; set; }

        // Внешние ключи
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
