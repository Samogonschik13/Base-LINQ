using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityLinqTemplate.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }

        // Внешний ключ и связь с группой
        public int GroupId { get; set; }
        public Group? Group { get; set; }

        // Связь с оценками
        public List<Grade> Grades { get; set; } = new();
    }
}
