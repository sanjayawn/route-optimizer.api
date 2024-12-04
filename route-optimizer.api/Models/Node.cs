namespace route_optimizer.api.Models
{
    public class Node
    {
        public string Name { get; set; }
        public List<Edge> Neighbors { get; set; } = new List<Edge>();
    }
}
