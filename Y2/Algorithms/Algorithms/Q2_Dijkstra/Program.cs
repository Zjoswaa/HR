
using System.Text;
using Solution;

var rand = new Random();

Console.WriteLine("Debug Q2");

var inf = double.PositiveInfinity;

double [,] graph = new double[,]{
    {inf, 8  , 1  , inf, inf, inf},
    {87 , inf, inf, 2  , inf, inf},
    {1  , inf, inf, 35 , inf, inf},
    {inf, 25 , 3  , inf, 41 , 6  },
    {inf, inf, inf, 4  , inf, 56 },
    {inf, inf, inf, 72 , 1  , inf}
};

Console.WriteLine("Given Graph:");
Exam.Helper.Display(graph);
var node = rand.Next(0, graph.GetLength(0));
var neighbors = Q2.Neighbors(graph,node);
Console.WriteLine($"\nNeighbours of node: {node}");
Exam.Helper.Display(neighbors.ToArray());
Console.WriteLine("\nDijkstra Distance Initialization (for all sources)");
int Count = graph.GetLength(0);
List<int> unvisitedNodes = new List<int>(Count);
for(int i = 0; i < graph.GetLength(0); ++i) {
  unvisitedNodes = new List<int>(Count);
  Exam.Helper.Display(Q2.Initialize(graph, i, unvisitedNodes).Item1);
}
Console.WriteLine("\nDijkstra Previous nodes Initialization (for all sources)");
for(int i = 0; i < graph.GetLength(0); ++i) { 
  unvisitedNodes = new List<int>(Count);
  Exam.Helper.Display(Q2.Initialize(graph, i, unvisitedNodes).Item2);
} 
int srcIdx = 0;
unvisitedNodes = new List<int>(Count);
Q2.Initialize(graph, srcIdx, unvisitedNodes);
Console.WriteLine($"\nSource: {srcIdx}. Unvisited Nodes:");
Exam.Helper.Display(unvisitedNodes); 

srcIdx = 2;
unvisitedNodes = new List<int>(Count);
Q2.Initialize(graph, srcIdx, unvisitedNodes);
Console.WriteLine($"\nSource: {srcIdx}. Unvisited Nodes:");
Exam.Helper.Display(unvisitedNodes);

var distPrev = Q2.Dijkstra(graph, node, Q2.Initialize, Q2.Neighbors);
Console.WriteLine($"\nDijkstra Distance array for source: {node}");
Exam.Helper.Display(distPrev.Item1);
Console.WriteLine($"\nDijkstra Previous array for source: {node}");
Exam.Helper.Display(distPrev.Item2);
var y = Q2.DijkstraForAll(graph, (double[,] graph, int source) => Q2.Dijkstra(graph, source, Q2.Initialize, Q2.Neighbors));
Console.WriteLine("\nDijkstra For All Distance arrays:");
Exam.Helper.Display(y.Item1);
Console.WriteLine("\nDijkstra For All Previous nodes arrays:");
Exam.Helper.Display(y.Item2);

Console.WriteLine();
