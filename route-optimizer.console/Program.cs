using route_optimizer.api.Services;

var shortestPathService = new ShortestPathService();

Console.Write("Enter the starting node: ");
var fromNode = Console.ReadLine();

Console.Write("Enter the destination node: ");
var toNode = Console.ReadLine();

var result = shortestPathService.CalculateShortestPath(fromNode, toNode);

if (result.NodeNames.Count == 1 && result.NodeNames[0] == "No path found")
{
    Console.WriteLine("No path found between the specified nodes.");
}
else if (result.NodeNames.Count == 1 && result.NodeNames[0] == "Invalid node name(s)")
{
    Console.WriteLine("Invalid node name(s) provided.");
}
else
{
    Console.WriteLine("Shortest path:");
    foreach (var node in result.NodeNames)
    {
        Console.Write(node + " -> ");
    }
    Console.WriteLine("\nTotal distance: " + result.Distance);
}
