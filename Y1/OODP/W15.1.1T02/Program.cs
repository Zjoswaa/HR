var array = new int[][] {
    new int[] { 1, 2, 3, 4, 5 },
    new int[] { 6, 7, 8, 9, 10 },
    new int[] { 11, 12, 13, 14, 15 },
    new int[] { 16, 17, 18, 19, 20 },
    new int[] { 21, 22, 23, 24, 25 }
};

int size = array.GetLength(0); // Assuming it's a square array.

// Transpose using LINQ
var transposed = Enumerable.Range(0, size)
    .Select(i => Enumerable.Range(0, size)
        .Select(j => array[j][i])
        .ToArray())
    .ToArray();

// Print the transposed array
foreach (var row in transposed) {
    Console.WriteLine(string.Join(" ", row));
}
