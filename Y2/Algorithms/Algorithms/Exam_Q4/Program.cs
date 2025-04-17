using Solution;

int[,] AdjMatrix = {
//    0, 1, 2, 3, 4, 5 
    { 0, 1, 1, 1, 0, 0 }, // 0 
    { 1, 0, 1, 1, 0, 0 }, // 1 
    { 1, 1, 0, 0, 1, 0 }, // 2 
    { 1, 1, 0, 0, 1, 1 }, // 3 
    { 0, 0, 1, 1, 0, 1 }, // 4 
    { 0, 0, 0, 1, 1, 0 }, // 5 
};

int[][] expected = [
    [1, 2, 3], // 0 is connected to 1, 2, 3 
    [0, 2, 3], // 1 is connected to 0, 2, 3 
    [0, 1, 4], // 2 is connected to 0, 1, 4 
    [0, 1, 4, 5], // 3 is connected to 0, 1, 4, 5 
    [2, 3, 5], // 4 is connected to 2, 3, 5
    [3, 4] // 5 is connected to 3, 4
];

var expectedString = String.Join("\n", expected.Select(_ => String.Join(",", _)));

var actual = Q4.ConvertMatrixToList(AdjMatrix);
var actualString = String.Join("\n", actual.Select(_ => String.Join(",", _)));

System.Console.WriteLine($"\nActual:\n{actualString}");
System.Console.WriteLine($"\nExpected:\n{expectedString}");
System.Console.WriteLine();
