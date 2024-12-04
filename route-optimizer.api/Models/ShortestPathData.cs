namespace route_optimizer.api.Models
{
    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; } = new List<string>();
        public int Distance { get; set; }
    }
}
