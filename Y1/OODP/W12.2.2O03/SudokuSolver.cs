static class SudokuSolver
{
    public static bool SolveSudoku(Sudoku sudoku)
    {
        (int Row, int Col) rowcol = FindEmptyCell(sudoku);
        int row = rowcol.Row;
        int col = rowcol.Col;
        if (row == -1 || col == -1)
        {
            return true;
        }

        for (int num = 1; num <= 9; num++)
        {
            if (IsSafe(sudoku, row, col, num))
            {
                sudoku[row, col] = num;

                if (SolveSudoku(sudoku))
                {
                    return true;
                }

                sudoku[row, col] = 0;
            }
        }

        return false;
    }

    private static (int Row, int Col) FindEmptyCell(Sudoku sudoku)
    {
        for (int row = 0; row < 9; row++)
            for (int col = 0; col < 9; col++)
                if (sudoku[row, col] == 0)
                    return (row, col); // Found an empty cell

        return (-1, -1); // No empty cells found
    }

    private static bool IsSafe(Sudoku sudoku, int row, int col, int num)
    {
        // Check row
        for (int i = 0; i < 9; i++)
        {
            if (sudoku[row, i] == num)
            {
                return false;
            }
        }

        // Check column
        for (int i = 0; i < 9; i++)
        {
            if (sudoku[i, col] == num)
            {
                return false;
            }
        }

        // Check 3x3 grid
        int startRow = (row / 3) * 3;
        int startCol = (col / 3) * 3;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (sudoku[startRow + i, startCol + j] == num)
                {
                    return false;
                }
            }
        }

        return true; // The number is safe to place
    }

    public static void PrintSudoku(Sudoku sudoku)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(sudoku[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
