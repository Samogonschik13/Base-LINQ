using System.Collections.Generic;

namespace ColonyLinq.Models
{
    public class Colonist
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public int CyclesLived { get; set; }

        public int BuildingId { get; set; }
        public Building? Building { get; set; }

        public List<Expedition> Expeditions { get; set; } = new();
    }
}