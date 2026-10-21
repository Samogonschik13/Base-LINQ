using System;
using System.Collections.Generic;

namespace UniversityLinqTemplate.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;       // "Водяной лёд", "Железная руда"
        public string ResourceType { get; set; } = string.Empty; // Вода, Металл, Энергия
        public int Quantity { get; set; }                      // Количество единиц

        // Связь с вылазкой, которая это добыла
        public int ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
    }
}