class Crossword {
    private char[,] Puzzle;

    public Crossword(char[,] Puzzle) {
        this.Puzzle = Puzzle;
    }

    public void FillWord((int Number, char Direction) Info, string Word) {
        // To store the position of the number
        (int X, int Y) Pos = (0, 0);

        // Check invalid number
        bool NumberValid = false;
        for (int y = 0; y < Puzzle.GetLength(0); y++) {
            for (int x = 0; x < Puzzle.GetLength(1); x++) {
                if (Puzzle[y,x].ToString() == Info.Number.ToString()) {
                    NumberValid = true;
                    Pos = (x, y);
                    break;
                }
            }
        }
        if (!NumberValid) {
            Console.WriteLine("Invalid number");
        }

        // Check if direction is valid
        if (!(Info.Direction == 'h' || Info.Direction == 'v')) {
            Console.WriteLine("Invalid direction");
        }

        // Return if any are the case, both need to be printed if they are both true so return later here
        if (!NumberValid || (!(Info.Direction == 'h' || Info.Direction == 'v'))) {
            return;
        }

        // Check if word will fit
        if (Info.Direction == 'h') {
            if (Pos.X + Word.Length > Puzzle.GetLength(1)) {
                Console.WriteLine("Word does not fit");
                return;
            }
        } else if (Info.Direction == 'v') {
            if (Pos.Y + Word.Length > Puzzle.GetLength(0)) {
                Console.WriteLine("Word does not fit");
                return;
            }
        }

        // Fill the word
        if (Info.Direction == 'h') {
            int counter = 0;
            foreach (char c in Word) {
                Puzzle[Pos.Y, Pos.X + counter] = c;
                counter++;
            }
        } else {
            int counter = 0;
            foreach (char c in Word) {
                Puzzle[Pos.Y + counter, Pos.X] = c;
                counter++;
            }
        }
    }

    public void PrintPuzzle() {
        for (int y = 0; y < Puzzle.GetLength(0); y++) {
            for (int x = 0; x < Puzzle.GetLength(1); x++) {
                Console.Write(Puzzle[y,x]);
            }

            // if (y < Puzzle.GetLength(0) - 1) {
            //     Console.WriteLine();
            // }
            Console.WriteLine();
        }
    }
}
