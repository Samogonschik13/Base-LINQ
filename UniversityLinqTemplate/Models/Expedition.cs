using System.Collections.Generic;

namespace ColonyLinq.Models
{
    public class Expedition
    {
        public int Id { get; set; }
        public string Target { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public int CommanderId { get; set; }
        public Colonist? Commander { get; set; }

        public List<Resource> Resources { get; set; } = new();
    }
}