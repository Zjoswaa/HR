static int askBoardSize() {
    while (true) {
        Console.Write("Board size: ");
        if (!int.TryParse(Console.ReadLine(), out int result)) {
            continue;
        }
        if (result > 2) {
            return result;
        }
    }
}

int boardSize = askBoardSize();
for (int i = 0; i < boardSize; i++) {
    for (int j = 0; j < boardSize; j++) {
        if (i % 2 == 0) {
            if (boardSize % 2 == 0 && j % 2 == 0 || boardSize % 2 == 1 && j % 2 == 1) {
                Console.Write("W");
            } else {
                Console.Write("B");
            }
        } else {
            if (boardSize % 2 == 0 && j % 2 == 0 || boardSize % 2 == 1 && j % 2 == 1) {
                Console.Write("B");
            } else {
                Console.Write("W");
            }
        }
        if (j == boardSize - 1 && i != boardSize - 1) {
            Console.WriteLine();
        }
    }
}
