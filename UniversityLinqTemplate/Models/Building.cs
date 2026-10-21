using System.Collections.Generic;

namespace ColonyLinq.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Condition { get; set; }

        public List<Colonist> Colonists { get; set; } = new();
    }
}