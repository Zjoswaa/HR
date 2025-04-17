using Solution;

const double inf = Double.PositiveInfinity;
var graph =
    new double[,] {
        { inf, 2, 15, inf, inf, 9 },
        { inf, inf, 12, 5, inf, inf },
        { inf, inf, inf, 7, inf, 19 },
        { inf, inf, 1, inf, 1, inf },
        { inf, inf, inf, inf, inf, 23 },
        { inf, inf, inf, inf, 13, inf },
    };

int start = 0;
int end = 4;

string nodes = "*: -1 (undefined); ";
for (var col = 0; col < graph.GetLength(0); col++) {
    var nodeCol = (char)('A' + col);
    nodes += $"{nodeCol}: {col}; ";
}
System.Console.WriteLine($"Adjacency matrix:\n{DisplayDistMatrix(graph)}");
var actualDistNextInit = Q5.Init(graph);
System.Console.WriteLine($"\nActual Dist Init:\n{DisplayDistMatrix(actualDistNextInit.Item1)}");
System.Console.WriteLine(
    $"\nNodes and correspective index:\n{nodes}\nActual Next Init:\n{DisplayNextMatrix(actualDistNextInit.Item2)}");

var actualDistNext = Q5.AllPairShortestPath(graph, Q5.Init);

System.Console.WriteLine($"\nActual Dist:\n{DisplayDistMatrix(actualDistNext.Item1)}");
System.Console.WriteLine(
    $"\nNodes and correspective index:\n{nodes}\nActual Next:\n{DisplayNextMatrix(actualDistNext.Item2)}");

int[] actualPath = Q5.ComputePath(actualDistNext.Item2, start, end).ToArray();

var actualPathString = string.Join(" -> ", actualPath);
var actualPathStringChar = string.Join(" -> ", actualPath.Select(_ => (char)('A' + _)));
var actualPathStringMsg = $"Actual Path from {(char)('A' + start)} to {(char)('A' + end)}: {actualPathStringChar}";
System.Console.WriteLine(
    $"Next matrix:\n{DisplayNextMatrix(actualDistNext.Item2)}\nNodes and correspective index:\n{nodes}\nActual Path from {start} to {end}: {actualPathString}\n{actualPathStringMsg}");


static string DisplayNextMatrix(int[,] matrix) {
    var res = "  ||";
    for (var col = 0; col < matrix.GetLength(1); col++) {
        var nodeCol = (char)('A' + col);
        res += $"  {nodeCol}  ||";
    }
    res += "\n";
    res += "----";
    for (var col = 0; col < matrix.GetLength(1); col++) {
        res += "-------";
    }
    res += "\n";

    for (var row = 0; row < matrix.GetLength(0); row++) {
        var nodeRow = (char)('A' + row);
        res += nodeRow + " ||";
        for (var col = 0; col < matrix.GetLength(1); col++) {
            var val = matrix[row, col];
            if (val == -1)
                res += "  *  ||";
            else
                res += $"  {(char)('A' + val)}  ||";
        }
        res += "\n";
        res += "----";
        for (var col = 0; col < matrix.GetLength(1); col++) {
            res += "-------";
        }
        res += "\n";
    }

    return res;
}

static string DisplayDistMatrix(double[,] matrix) {
    var res = "  ||";
    for (var col = 0; col < matrix.GetLength(1); col++) {
        var nodeCol = (char)('A' + col);
        res += $"  {nodeCol}  ||";
    }
    res += "\n";
    res += "----";
    for (var col = 0; col < matrix.GetLength(1); col++) {
        res += "-------";
    }
    res += "\n";

    for (var row = 0; row < matrix.GetLength(0); row++) {
        var nodeRow = (char)('A' + row);
        res += nodeRow + " ||";
        for (var col = 0; col < matrix.GetLength(1); col++) {
            var val = matrix[row, col];
            if (val == double.PositiveInfinity)
                res += $"  {val}  ||";
            else if (val >= 0 && val <= 9)
                res += $"  {val}  ||";
            else
                res += $" {val}  ||";
        }
        res += "\n";
        res += "----";
        for (var col = 0; col < matrix.GetLength(1); col++) {
            res += "-------";
        }
        res += "\n";
    }

    return res;
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
