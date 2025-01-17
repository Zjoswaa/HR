static class MazeSolver {
    public const char Path = ' ';
    public const char Wall = 'X';
    public const char Mark = 'o';

    public static bool Solve(char[,] maze, int startX, int startY, int endX, int endY) {
        PrintMaze(maze);
        
        if (!IsValidPosition(maze, startX, startY)) {
            return false;
        }
        if (startX == endX && startY == endY) {
            return true;
        }

        maze[startX, startY] = Mark;

        if (IsValidPosition(maze, startX + 1, startY) && Solve(maze, startX + 1, startY, endX, endY)) {
            return true;
        }
        if (IsValidPosition(maze, startX - 1, startY) && Solve(maze, startX - 1, startY, endX, endY)) {
            return true;
        }
        if (IsValidPosition(maze, startX, startY + 1) && Solve(maze, startX, startY + 1, endX, endY)) {
            return true;
        }
        if (IsValidPosition(maze, startX, startY - 1) && Solve(maze, startX, startY - 1, endX, endY)) {
            return true;
        }
        
        maze[startX, startY] = Path;
        return false;
    }

    public static void PrintMaze(char[,] maze) {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Console.Write(maze[i, j] + " "); // Open path
            }
            Console.WriteLine();
        }
    }

    private static bool IsValidPosition(char[,] maze, int x, int y) {
        return x >= 0 && y >= 0 && y < maze.GetLength(1) && x < maze.GetLength(0) && maze[x, y] == Path;
    }
}
