using System;
using System.Collections.Generic;
using UniversityLinqTemplate.Data;

namespace UniversityLinqTemplate.Models
{
    public class Expedition
    {
        public int Id { get; set; }
        public string Target { get; set; } = string.Empty;     // Цель: "Поиск льда"
        public string Status { get; set; } = string.Empty;     // Успешна, Провалена

        // Связь с командиром вылазки
        public int CommanderId { get; set; }
        public Colonist? Commander { get; set; }

        // Связь с добытыми ресурсами
        public List<Resource> Resources { get; set; } = new();
    }
}