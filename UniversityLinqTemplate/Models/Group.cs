using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityLinqTemplate.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Например, "ИТ-21"
        public int CourseNumber { get; set; }           // 1, 2, 3 или 4 курс

        // Навигационное свойство: у одной группы много студентов
        public List<Student> Students { get; set; } = new();
    }
}
