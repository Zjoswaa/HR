static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Indexer": TestIndexer(); return;
            case "Solve": Solve(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestIndexer()
    {
        int[,] board = {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 },
        };

        Sudoku sudoku = new(board);

        for (int i = 0; i < board.GetLength(0); i += 3)
            for (int j = 0; j < board.GetLength(1); j += 3)
                Console.WriteLine($"Row: {i}, Col: {j}, Number: {sudoku[i, j]}");
    }

    private static void PrintIsSolved(bool isSolved, Sudoku sudoku)
    {
        if (!isSolved)
        {
            Console.WriteLine("No solution exists.");
            return;
        }

        Console.WriteLine("Solved Sudoku:");
        SudokuSolver.PrintSudoku(sudoku);
    }

    public static void Solve()
    {
        TestBoard1();
        TestBoard2();
        TestBoard3();
    }

    public static void TestBoard1()
    {
        Console.WriteLine("BOARD 1");

        int[,] board = {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 },
        };

        Sudoku sudoku = new(board);
        PrintIsSolved(SudokuSolver.SolveSudoku(sudoku), sudoku);
    }

    public static void TestBoard2()
    {
        Console.WriteLine("\nBOARD 2");

        int[,] board = {
            { 8, 5, 0, 0, 0, 2, 4, 0, 0 },
            { 7, 2, 0, 0, 0, 0, 0, 0, 9 },
            { 0, 0, 4, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 0, 7, 0, 0, 2 },
            { 3, 0, 5, 0, 0, 0, 9, 0, 0 },
            { 0, 4, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 0 },
            { 0, 1, 7, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 3, 6, 0, 4, 0 },
        };

        Sudoku sudoku = new(board);
        PrintIsSolved(SudokuSolver.SolveSudoku(sudoku), sudoku);
    }

    public static void TestBoard3()
    {
        Console.WriteLine("\nBOARD 3");

        int[,] board = {
            { 0, 0, 0, 0, 0, 0, 8, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 0, 0, 0, 0, 0, 4, 0, 0, 0 },
            { 0, 7, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 3, 5, 0, 4, 0, 0 },
            { 0, 9, 2, 0, 0, 0, 0, 0, 0 },
            { 5, 0, 0, 0, 8, 0, 0, 0, 0 },
            { 0, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 1, 7, 0 },
        };

        Sudoku sudoku = new(board);
        PrintIsSolved(SudokuSolver.SolveSudoku(sudoku), sudoku);
    }
}
