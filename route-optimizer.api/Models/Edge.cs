using System.Xml.Linq;

namespace route_optimizer.api.Models
{
    public class Edge
    {
        public Node ToNode { get; set; }
        public int Weight { get; set; }
    }
}
