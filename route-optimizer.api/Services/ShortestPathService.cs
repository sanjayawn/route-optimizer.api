using route_optimizer.api.Models;

namespace route_optimizer.api.Services
{
    public class ShortestPathService:IShortestPathService
    {
        private readonly List<Node> _graph;

        public ShortestPathService()
        {
            // Create unique node objects
            var nodeA = new Node { Name = "A" };
            var nodeB = new Node { Name = "B" };
            var nodeC = new Node { Name = "C" };
            var nodeD = new Node { Name = "D" };
            var nodeE = new Node { Name = "E" };
            var nodeF = new Node { Name = "F" };
            var nodeG = new Node { Name = "G" };
            var nodeH = new Node { Name = "H" };
            var nodeI = new Node { Name = "I" };

            // Assign neighbors and weights
            nodeA.Neighbors = new List<Edge>
            {
                new Edge { ToNode = nodeB, Weight = 4 },
                new Edge { ToNode = nodeC, Weight = 6 }
            };

            nodeB.Neighbors = new List<Edge>
            {
                new Edge { ToNode = nodeA, Weight = 4 },
                new Edge { ToNode = nodeF, Weight = 2 }
            };

            nodeC.Neighbors = new List<Edge>
            {
                new Edge { ToNode = nodeA, Weight = 6 },
                new Edge { ToNode = nodeD, Weight = 8 }
            };

            nodeD.Neighbors = new List<Edge>
            {
                new Edge { ToNode = nodeC, Weight = 8 },
                new Edge { ToNode = nodeE, Weight = 4 },
                new Edge { ToNode = nodeG, Weight = 1 }
            };

            nodeE.Neighbors = new List<Edge>
            {
                new Edge { ToNode = nodeD, Weight = 4 },
                new Edge { ToNode = nodeF, Weight = 3 },
                new Edge { ToNode = nodeI, Weight = 8 }
            };

            nodeF.Neighbors = new List<Edge>
            {
                new Edge { ToNode = nodeB, Weight = 2 },
                new Edge { ToNode = nodeE, Weight = 3 },
                new Edge { ToNode = nodeH, Weight = 6 },
                new Edge { ToNode = nodeG, Weight = 4 }
            };

            nodeG.Neighbors = new List<Edge>
            {
                new Edge { ToNode = nodeD, Weight = 1 },
                new Edge { ToNode = nodeH, Weight = 5 },
                new Edge { ToNode = nodeI, Weight = 5 },
                new Edge { ToNode = nodeF, Weight = 4 }
            };

            nodeH.Neighbors = new List<Edge>
            {
                new Edge { ToNode = nodeF, Weight = 6 },
                new Edge { ToNode = nodeG, Weight = 5 }
            };

            nodeI.Neighbors = new List<Edge>
            {
                new Edge { ToNode = nodeE, Weight = 8 },
                new Edge { ToNode = nodeG, Weight = 5 }
            };

            // Construct the graph
            _graph = new List<Node> { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };
        }

        public ShortestPathData CalculateShortestPath(string fromNodeName, string toNodeName)
        {
            // Check if the fromNodeName and toNodeName exist in the graph
            var fromNode = _graph.FirstOrDefault(n => n.Name == fromNodeName);
            var toNode = _graph.FirstOrDefault(n => n.Name == toNodeName);

            if (fromNode == null || toNode == null)
            {
                // If either node is not found, return a response indicating the error
                return new ShortestPathData
                {
                    NodeNames = new List<string> { "Invalid node name(s)" },
                    Distance = -1
                };
            }

            var distances = new Dictionary<string, int>();
            var previousNodes = new Dictionary<string, string>();
            var unvisitedNodes = new HashSet<Node>(_graph);
            var priorityQueue = new PriorityQueue<(Node, int), int>(); // Prioritize by distance

            // Initialize distances and add nodes to the priority queue
            foreach (var node in _graph)
            {
                distances[node.Name] = int.MaxValue;
                previousNodes[node.Name] = null;
                priorityQueue.Enqueue((node, int.MaxValue), int.MaxValue);
            }

            distances[fromNodeName] = 0;
            priorityQueue.Enqueue((fromNode, 0), 0);

            while (priorityQueue.Count > 0)
            {
                var (currentNode, currentDistance) = priorityQueue.Dequeue();

                // Skip if the current node has already been processed with a shorter distance
                if (currentDistance > distances[currentNode.Name])
                {
                    continue;
                }

                foreach (var edge in currentNode.Neighbors)
                {
                    var neighbor = edge.ToNode;
                    var tentativeDistance = currentDistance + edge.Weight;

                    if (tentativeDistance < distances[neighbor.Name])
                    {
                        distances[neighbor.Name] = tentativeDistance;
                        previousNodes[neighbor.Name] = currentNode.Name;
                        priorityQueue.Enqueue((neighbor, tentativeDistance), tentativeDistance);
                    }
                }
            }

            // Backtrack to find the path
            var path = new List<string>();
            var current = toNodeName;
            while (current != null)
            {
                path.Insert(0, current);
                current = previousNodes[current];
            }

            // If the path is empty or the distance is still MaxValue, it means no path exists
            if (path.Count == 1 && path[0] != toNodeName)
            {
                return new ShortestPathData
                {
                    NodeNames = new List<string> { "No path found" },
                    Distance = -1
                };
            }

            return new ShortestPathData
            {
                NodeNames = path,
                Distance = distances[toNodeName]
            };
        }




    }
}
