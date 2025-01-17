class Sudoku {
    private int[,] Board;

    public int this[int x, int y] {
        get => Board[x, y];
        set => Board[x, y] = value;
    }

    public Sudoku(int[,] board) {
        Board = board;
    }
}
