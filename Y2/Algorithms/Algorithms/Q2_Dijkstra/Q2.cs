namespace Solution;

public class Q2
{   
    public static Tuple<double[], int[]> Initialize(double[,] graph, int source, List<int> unvisitedNodes) {
        double[] distance = new double[graph.GetLength(0)];
        int[] prev = new int[graph.GetLength(0)];
        // Add source first
        unvisitedNodes.Add(source);
        for (int i = 0; i < graph.GetLength(0); i++) {
            distance[i] = Double.PositiveInfinity;
            prev[i] = -1;
            // Dont add source twice
            if (i != source) {
                unvisitedNodes.Add(i);
            }
        }
        distance[source] = 0;
        return new Tuple<double[], int[]>(distance, prev);
    }

    public static Tuple<double[], int[]> Dijkstra(double[,] graph, int source, Func<double[,], int, List<int>, Tuple<double[], int[]>> initializeFunc, Func<double[,],int, List<int>> neighborsFunc) {  
        // ToDo 2.1: Dijkstra for single source shortest path
        
        int Count = graph.GetLength(0);
        double[] distance;
        int[] prev;
        List<int> unvisitedNodes = new List<int>(Count);
        
        // initialization of distance, prev and unvisitedNodes 
        // here the provided method initialize is used:
        (distance, prev) = Initialize(graph, source, unvisitedNodes);

        //until unvisitedNodes is empty
        while (unvisitedNodes.Count != 0) {
            // find closest node in unvisitedNodes
            int closestNode = 0;
            double closestDistance = Double.PositiveInfinity;
            foreach (int node in unvisitedNodes) {
                if (distance[node] < closestDistance) {
                    closestNode = node;
                    closestDistance = distance[node];
                }
            }
            // remove the closest node from unvisitedNodes
            unvisitedNodes.Remove(closestNode);
            // considering all neighboring (unvisited) nodes
            // (method: neighborsFunc can be used here)
            foreach (int neighbor in Neighbors(graph, closestNode)) {
                double alt = distance[closestNode] + graph[closestNode, neighbor];
                // update distance and prev arrays when needed
                if (alt < distance[neighbor]) {
                    distance[neighbor] = alt;
                    prev[neighbor] = closestNode;
                }
            }
        }

        return new Tuple<double[], int[]>(distance, prev);
    }

    public static Tuple<double[][], int[][]> DijkstraForAll(double[,] graph, Func<double[,], int, Tuple<double[], int[]>> dijkstraFunc) {
        double[][] distances = new double[graph.GetLength(0)][];
        int[][] previouses = new int[graph.GetLength(0)][];

        for (int i = 0; i < graph.GetLength(1); i++) {
            // Tuple<double[], int[]> dijkstraResult = dijkstraFunc(graph, i);
            // distances[i] = dijkstraResult.Item1;
            // previouses[i] = dijkstraResult.Item2;
            (distances[i], previouses[i]) = dijkstraFunc(graph, i);
        }
        return new Tuple<double[][], int[][]>(distances, previouses);
    }
    
    public static List<int> Neighbors(double[,] graph, int node) { 
        List<int> neighbors = new List<int>();
        for (int i = 0; i < graph.GetLength(0); i++) {
            if (!Double.IsPositiveInfinity(graph[node, i])) {
                neighbors.Add(i);
            }
        }
        return neighbors;
    }
}
