static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "1": Maze1(); return;
            case "2": Maze2(); return;
            case "3": Maze3(); return;
            case "4": Maze4(); return;
            default: throw new ArgumentException();
        }
    }

    static void PrintIsSolvable(char[,] maze, bool isSolvable)
    {
        if (isSolvable)
        {
            Console.WriteLine("Maze has a solution:");
            MazeSolver.PrintMaze(maze);
        }
        else
        {
            Console.WriteLine("Maze has no solution");
        }
    }

    static void Maze1()
    {
        // Simple maze: from top left to bottom right
        char[,] maze = {
            {' ', 'X', ' ', ' ', ' '},
            {' ', 'X', ' ', 'X', ' '},
            {' ', ' ', ' ', ' ', ' '},
            {' ', 'X', 'X', 'X', ' '},
            {' ', ' ', ' ', ' ', ' '},
        };

        int startX = 0;
        int startY = 0;
        int endX = 4;
        int endY = 4;

        bool isSolvable = MazeSolver.Solve(maze, startX, startY, endX, endY);
        PrintIsSolvable(maze, isSolvable);
    }

    static void Maze2()
    {
        // From bottom left to bottom center(ish)
        char[,] maze = {
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {'X', ' ', 'X', 'X', ' ', 'X', ' '},
            {'X', ' ', ' ', ' ', 'X', ' ', ' '},
            {' ', ' ', 'X', ' ', ' ', 'X', ' '},
            {' ', 'X', ' ', 'X', 'X', ' ', ' '},
            {' ', 'X', ' ', 'X', 'X', ' ', 'X'},
            {' ', ' ', 'X', 'X', ' ', ' ', ' '},
        };

        int startX = 0;
        int startY = 6;
        int endX = 4;
        int endY = 6;

        bool isSolvable = MazeSolver.Solve(maze, startX, startY, endX, endY);
        PrintIsSolvable(maze, isSolvable);
    }

    static void Maze3()
    {
        // Impossible maze
        char[,] maze = {
            {' ', 'X', ' ', 'X', 'X', ' ', ' '},
            {' ', ' ', 'X', 'X', ' ', 'X', ' '},
            {'X', ' ', ' ', ' ', 'X', 'X', ' '},
            {' ', 'X', 'X', 'X', ' ', 'X', ' '},
            {' ', 'X', ' ', 'X', 'X', ' ', ' '},
            {' ', ' ', 'X', 'X', ' ', ' ', ' '},
        };

        int startX = 0;
        int startY = 0;
        int endX = 4;
        int endY = 5;

        bool isSolvable = MazeSolver.Solve(maze, startX, startY, endX, endY);
        PrintIsSolvable(maze, isSolvable);
    }

    static void Maze4()
    {
        // From center(ish) to top left
        char[,] maze = {
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {'X', 'X', 'X', 'X', 'X', 'X', ' '},
            {' ', ' ', ' ', ' ', ' ', 'X', ' '},
            {' ', 'X', 'X', 'X', ' ', 'X', ' '},
            {' ', 'X', ' ', ' ', ' ', 'X', ' '},
            {' ', 'X', 'X', 'X', 'X', 'X', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        };

        int startX = 2;
        int startY = 4;
        int endX = 0;
        int endY = 0;

        bool isSolvable = MazeSolver.Solve(maze, startX, startY, endX, endY);
        PrintIsSolvable(maze, isSolvable);
    }
}
