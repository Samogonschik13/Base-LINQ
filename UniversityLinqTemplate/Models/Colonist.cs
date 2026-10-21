using System;
using System.Collections.Generic;
using UniversityLinqTemplate.Data;

namespace UniversityLinqTemplate.Models
{
    public class Colonist
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty; // Инженер, Геолог, Ботаник
        public int CyclesLived { get; set; }                   // Возраст в циклах

        // Связь со зданием
        public int BuildingId { get; set; }
        public Building? Building { get; set; }

        // Связь с вылазками (колонист может быть командиром в нескольких)
        public List<Expedition> Expeditions { get; set; } = new();
    }
}