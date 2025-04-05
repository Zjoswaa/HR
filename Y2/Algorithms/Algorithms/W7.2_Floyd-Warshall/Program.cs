using System.Text;
using Solution;

var inf = double.PositiveInfinity;

//Adjacency matrix:

double[,] graph = {
    { inf, 3, inf, 5 },
    { 2, inf, inf, inf },
    { inf, 7, inf, 1 },
    { inf, inf, 6, inf }
};

//Init Test:    

double[,] expectedDistances = {
    { 0, 3, inf, 5 },
    { 2, 0, inf, inf },
    { inf, 7, 0, 1 },
    { inf, inf, 6, 0 }
};

int[,] expectedNextNodes = {
    { -1, 1, -1, 3 },
    { 0, -1, -1, -1 },
    { -1, 1, -1, 3 },
    { -1, -1, 2, -1 }
};

var (distances, nextNodes) = FloydWarshall.Init(graph);

var msg = FormativeFeedback(graph, expectedDistances, expectedNextNodes, distances, nextNodes);

var flag = MatrixEquality(expectedDistances, distances) &&
           MatrixEquality(expectedNextNodes, nextNodes);

System.Console.WriteLine("\n\n-----Init Test:-----\n  ");
System.Console.WriteLine(msg);
System.Console.WriteLine($"Matrix Equality: {flag}\n");

//AllPairShortestPath Test:

expectedDistances = new double[,] {
    { 0, 3, 11, 5 },
    { 2, 0, 13, 7 },
    { 9, 7, 0, 1 },
    { 15, 13, 6, 0 }
};

expectedNextNodes = new int[,] {
    { -1, 1, 3, 3 },
    { 0, -1, 0, 0 },
    { 1, 1, -1, 3 },
    { 2, 2, 2, -1 }
};

(distances, nextNodes) = FloydWarshall.AllPairShortestPath(graph);

msg = FormativeFeedback(graph, expectedDistances, expectedNextNodes, distances, nextNodes);
flag = MatrixEquality(expectedDistances, distances) &&
       MatrixEquality(expectedNextNodes, nextNodes);

System.Console.WriteLine("\n\n-----AllPairShortestPath Test:-----\n  ");
System.Console.WriteLine(msg);
System.Console.WriteLine($"Matrix Equality: {flag}\n");


static string FormativeFeedback(double[,] graph, double[,] expectedDistances, int[,] expectedNextNodes,
    double[,] actualDistances, int[,] actualNextNodes) {
    StringBuilder ret = new StringBuilder();
    ret.AppendLine("Formative Feedback:\n");
    ret.AppendLine("Input: Graph");
    ret.AppendLine(DisplayMatrix(graph));

    ret.AppendLine("  --Expected Output:--\n");
    ret.AppendLine("Expected Distance");
    ret.AppendLine(DisplayMatrix(expectedDistances));

    ret.AppendLine("Expected Next");
    ret.AppendLine(DisplayMatrix(expectedNextNodes));

    ret.AppendLine("  --Actual Output:--\n");
    ret.AppendLine("Actual Distance");
    ret.AppendLine(DisplayMatrix(actualDistances));

    ret.AppendLine("Actual Next");
    ret.AppendLine(DisplayMatrix(actualNextNodes));
    return ret.ToString();
}

static string DisplayMatrix<T>(T[,] matrix) {
    var ret = new StringBuilder();
    for (int i = 0; i < matrix.GetLength(0); ++i) {
        for (int j = 0; j < matrix.GetLength(1); ++j) {
            ret.Append($"{matrix[i, j]}\t");
        }
        ret.AppendLine();
    }
    return ret.ToString();
}

static bool MatrixEquality<T>(T[,] m1, T[,] m2) {
    if (m1 == null || m2 == null || m1.Length != m2.Length || m1.GetLength(0) != m2.GetLength(0)) return false;
    for (int i = 0; i < m1.GetLength(0); i++) {
        for (int j = 0; j < m1.GetLength(1); j++) {
            if (m1[i, j].Equals(m2[i, j]) == false) return false;
        }
    }
    return true;
}
