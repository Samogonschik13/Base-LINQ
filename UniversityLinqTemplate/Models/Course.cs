using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityLinqTemplate.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Например, "Базы данных"
        public int Credits { get; set; }                  // Трудоемкость (часы / зачетные единицы)

        public List<Grade> Grades { get; set; } = new();
    }
}
