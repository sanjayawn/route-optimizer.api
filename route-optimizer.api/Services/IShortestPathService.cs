using route_optimizer.api.Models;

namespace route_optimizer.api.Services
{
    public interface IShortestPathService
    {
        ShortestPathData CalculateShortestPath(string fromNodeName, string toNodeName);
    }
}
