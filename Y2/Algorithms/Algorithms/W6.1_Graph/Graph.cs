namespace Solution;

public class Graph {
    public double[,] AdjacencyMatrix { get; set; }

    public int Count => AdjacencyMatrix.GetLength(0); //Number of nodes in the graph

    public Graph(double[,] matrix) {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new System.ArgumentException("The adjacency matrix must be a square matrix");
        AdjacencyMatrix = matrix;
    }

    // Breadth First Traversal
    public string BFT(int root) {
        string res = "";
        
        // create empty queue and enqueue the root
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(root);

        // create array of booleans to keep track of visited nodes and set the root flag to true
        bool[] visited = new bool[Count];
        for (int i = 0; i < Count; i++) {
            visited[i] = false;
        }
        visited[root] = true;

        // Loop until queue is empty
        while (queue.Count != 0) {
            // dequeue a node
            int node = queue.Dequeue();

            // add the current node (followed by a space) to the string
            res += $"{node} ";

            // find neighbors of current
            // enqueue all neighbors which are not visited yet and set them to visited
            foreach (int neighbor in Neighbors(node)) {
                if (!visited[neighbor]) {
                    queue.Enqueue(neighbor);
                    visited[neighbor] = true;
                }
            }
        }
        
        return res;
    }

    //Depth First Traveral
    public string DFT(int root) {
        string res = "";

        // create empty stack and push the root into it
        Stack<int> stack = new Stack<int>();
        stack.Push(root);

        // create array of booleans to keep track of visited nodes
        bool[] visited = new bool[Count];
        for (int i = 0; i < Count; i++) {
            visited[i] = false;
        }

        // Loop until stack is empty
        while (stack.Count != 0) {
            // pop a node from the stack
            int node = stack.Pop();

            // check if current node is not visited yet
            // add current node to the string (followed by a space) and set it to visited
            if (!visited[node]) {
                res += $"{node} ";
                visited[node] = true;

                // find neighbors (in reversed order) of current
                // push all neighbors
                foreach (int neighbor in NeighborsReversed(node)) {
                    stack.Push(neighbor);
                }
            }
        }

        return res;
    }

    //Dijkstra's algorithm SingleSourceShortestPath
    public Tuple<double[], int[]> SingleSourceShortestPath(int source) { //distance and prev arrays
        // initialization of distance, prev and unvisitedNodes
        // default distance: double.PositiveInfinity
        // default previous node: -1
        double[] distance = new double[Count];
        int[] prev = new int[Count];
        List<int> unvisitedNodes = new List<int>();
        for (int i = 0; i < Count; i++) {
            distance[i] = double.PositiveInfinity;
            prev[i] = -1;
            unvisitedNodes.Add(i);
        }

        // set distance of source
        distance[source] = 0;

        // Loop until unvisitedNodes is empty
        while (unvisitedNodes.Count != 0) {
            // find closest node in unvisitedNodes
            int closestNode = 0;
            double closestDistance = double.PositiveInfinity;
            foreach (int node in unvisitedNodes) {
                if (distance[node] < closestDistance) {
                    closestNode = node;
                    closestDistance = distance[node];
                }
            }

            // remove the closest node from unvisitedNodes
            unvisitedNodes.Remove(closestNode);

            // considering all neighbors of the closest node
            foreach (int neighbor in Neighbors(closestNode)) {
                // calculate distance and update distance (and previous node) if smaller
                double alt = distance[closestNode] + AdjacencyMatrix[closestNode, neighbor];
                if (alt < distance[neighbor]) {
                    distance[neighbor] = alt;
                    prev[neighbor] = closestNode;
                }
            }
        }

        return new Tuple<double[], int[]>(distance, prev);
    }

    //Nodes adjacent to a given node
    public List<int> Neighbors(int node) {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++) {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        return neighbors;
    }

    //Nodes (adjacent to a given node) to be visited in reversed order
    public List<int> NeighborsReversed(int node) {
        List<int> neighbors = new List<int>();
        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++) {
            if (AdjacencyMatrix[node, i] < Double.PositiveInfinity)
                neighbors.Add(i);
        }
        neighbors.Reverse();
        return neighbors;
    }
}
