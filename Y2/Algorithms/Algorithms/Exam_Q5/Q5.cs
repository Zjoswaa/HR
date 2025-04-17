namespace Solution;

public static class Q5 {

    public static Tuple<double[,], int[,]> Init(double[,] graph) {
        double[,] distance = new double[graph.GetLength(0), graph.GetLength(1)];
        int[,] next = new int[graph.GetLength(0), graph.GetLength(1)];

        for (int i = 0; i < graph.GetLength(0); i++) {
            for (int j = 0; j < graph.GetLength(1); j++) {
                if (i == j) {
                    distance[i, j] = 0;
                }
                else {
                    distance[i, j] = graph[i, j];
                }
                if (Double.IsPositiveInfinity(graph[i, j])) {
                    next[i, j] = -1;
                }
                else {
                    next[i, j] = j;
                }
            }
        }

        return new Tuple<double[,], int[,]>(distance, next);
    }

    public static Tuple<double[,], int[,]> AllPairShortestPath(double[,] graph,
        Func<double[,], Tuple<double[,], int[,]>> initFunc) {
        var (dist, next) = initFunc(graph);

        for (int k = 0; k < graph.GetLength(0); k++) {
            for (int i = 0; i < graph.GetLength(0); i++) {
                for (int j = 0; j < graph.GetLength(0); j++) {
                    if (dist[i, k] + dist[k, j] < dist[i, j]) {
                        dist[i, j] = dist[i, k] + dist[k, j];
                        next[i, j] = next[i, k];
                    }
                }
            }
        }

        return new Tuple<double[,], int[,]>(dist, next);
    }

    public static List<int> ComputePath(int[,] nextMatrix, int u, int v) {
        if (u == v) {
            return new List<int>();
        }
        List<int> route = new List<int>();

        route.Add(u);
        while (u != v) {
            route.Add(nextMatrix[u, v]);
            u = nextMatrix[u, v];
        }

        return route;
    }
}
