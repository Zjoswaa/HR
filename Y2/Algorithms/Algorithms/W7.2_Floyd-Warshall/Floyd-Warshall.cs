namespace Solution;

public class FloydWarshall {
    public static Tuple<double[,], int[,]> Init(double[,] graph) {
        int n = graph.GetLength(0);
        double[,] distance = new double[n, n];
        int[,] next = new int[n, n];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (i == j) {
                    distance[i, j] = 0;
                } else {
                    distance[i, j] = graph[i, j];
                }
                if (i != j && !double.IsPositiveInfinity(graph[i, j])) {
                    next[i, j] = j;
                } else {
                    next[i, j] = -1;
                }
            }
        }

        return new Tuple<double[,], int[,]>(distance, next);
    }

    public static Tuple<double[,], int[,]> AllPairShortestPath(double[,] graph) {
        var (dist, next) = Init(graph);

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
}
