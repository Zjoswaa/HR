static class Program {
    static void Main() {
        char[,] Board = new char[3, 3] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}
        };

        bool PlayerOneTurn = true;
        
        // 0: no winner, no tie
        // 1: X wins
        // 2: O wins
        // 3: tie
        int GameStatus = 0;
        
        while (GameStatus == 0) {
            PrintBoard();
            Console.WriteLine();
            Console.Write($"Player {(PlayerOneTurn ? "X" : "O")}, please enter your move (row, column): ");
            String? Input = Console.ReadLine();
            if (Input?.ToUpper() == "Q") {
                return;
            }
            int[]? Move = Input?.Split(",").Select(int.Parse).ToArray();

            Board[Move[0] - 1, Move[1] - 1] = PlayerOneTurn ? 'X' : 'O';
            
            GameStatus = CheckGameEnd();
            PlayerOneTurn = !PlayerOneTurn;
        }

        PrintBoard();
        if (GameStatus == 1) {
            Console.WriteLine("X wins!");
        } else if (GameStatus == 2) {
            Console.WriteLine("O wins!");
        } else {
            Console.WriteLine("It's a tie!");
        }

        void PrintBoard() {
            Console.WriteLine($" {Board[0,0]} | {Board[0, 1]} | {Board[0, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Board[1, 0]} | {Board[1, 1]} | {Board[1, 2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Board[2, 0]} | {Board[2, 1]} | {Board[2, 2]} ");
        }
        
        int CheckGameEnd() {
            // Horizontal wins
            if (Board[0, 0] == 'X' && Board[0, 1] == 'X' && Board[0, 2] == 'X') {
                return 1;
            }
            if (Board[0, 0] == 'O' && Board[0, 1] == 'O' && Board[0, 2] == 'O') {
                return 2;
            }
            if (Board[1, 0] == 'X' && Board[1, 1] == 'X' && Board[1, 2] == 'X') {
                return 1;
            }
            if (Board[1, 0] == 'O' && Board[1, 1] == 'O' && Board[1, 2] == 'O') {
                return 2;
            }
            if (Board[2, 0] == 'X' && Board[2, 1] == 'X' && Board[2, 2] == 'X') {
                return 1;
            }
            if (Board[2, 0] == 'O' && Board[2, 1] == 'O' && Board[2, 2] == 'O') {
                return 2;
            }

            // Vertical wins
            if (Board[0, 0] == 'X' && Board[1, 0] == 'X' && Board[2, 0] == 'X') {
                return 1;
            }
            if (Board[0, 0] == 'O' && Board[1, 0] == 'O' && Board[2, 0] == 'O') {
                return 2;
            }
            if (Board[0, 1] == 'X' && Board[1, 1] == 'X' && Board[2, 1] == 'X') {
                return 1;
            }
            if (Board[0, 1] == 'O' && Board[1, 1] == 'O' && Board[2, 1] == 'O') {
                return 2;
            }
            if (Board[0, 2] == 'X' && Board[1, 2] == 'X' && Board[2, 2] == 'X') {
                return 1;
            }
            if (Board[0, 2] == 'O' && Board[1, 2] == 'O' && Board[2, 2] == 'O') {
                return 2;
            }
            
            // Diagonal wins
            if (Board[0, 0] == 'X' && Board[1, 1] == 'X' && Board[2, 2] == 'X') {
                return 1;
            }
            if (Board[0, 0] == 'O' && Board[1, 1] == 'O' && Board[2, 2] == 'O') {
                return 2;
            }
            if (Board[0, 2] == 'X' && Board[1, 1] == 'X' && Board[2, 0] == 'X') {
                return 1;
            }
            if (Board[0, 2] == 'O' && Board[1, 1] == 'O' && Board[2, 0] == 'O') {
                return 2;
            }
            
            // Tie check
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    // If any spot on the board is empty
                    if (Board[i, j] == ' ') {
                        return 0;
                    }
                }
            }

            // No winner, no empty spots on the board
            return 3;
        }
    }
}
