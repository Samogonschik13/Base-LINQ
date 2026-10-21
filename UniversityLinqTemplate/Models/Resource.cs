namespace ColonyLinq.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ResourceType { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public int ExpeditionId { get; set; }
        public Expedition? Expedition { get; set; }
    }
}