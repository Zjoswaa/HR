static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Happy":
                TestFillWordHappy();
                return;
            case "Invalid":
                TestFillWordInvalidNumberChar();
                return;
            case "TooLong":
                TestFillWordWordTooLong();
                return;
            //case "Indexer": TestIndexer(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestFillWordHappy() {
        char[,] puzzle1 = new char[,] {
            { '1', '#', '2', '3', '4' },
            { '#', '#', '#', '#', '5' },
            { '6', '7', '#', '8', 'V' },
            { 'W', '#', 'X', 'Y', 'Z' },
        };

        Crossword crossword1 = new(puzzle1);
        Console.WriteLine("Start:");
        crossword1.PrintPuzzle();

        Console.WriteLine("\n1 horizontal: APPLE");
        crossword1.FillWord((1, 'h'), "APPLE");
        crossword1.PrintPuzzle();

        Console.WriteLine("\n5 vertical: BAR");
        crossword1.FillWord((5, 'v'), "BAR");
        crossword1.PrintPuzzle();

        Console.WriteLine("\n7 horizontal: CHIN");
        crossword1.FillWord((7, 'h'), "CHIN");
        crossword1.PrintPuzzle();
        Console.WriteLine();

        char[,] puzzle2 = new char[,] {
            { '#', '1', '2', '#', '#' },
            { '#', '#', '#', '#', '#' },
            { '3', '#', '#', '#', '#' },
        };
        Crossword crossword2 = new(puzzle2);

        Console.WriteLine("1 vertical: DYE");
        crossword2.FillWord((1, 'v'), "DYE");
        Console.WriteLine("2 horizontal: OWL");
        crossword2.FillWord((2, 'h'), "OWL");
        Console.WriteLine("3 horizontal: OWL");
        crossword2.FillWord((3, 'h'), "HELLO");
        crossword1.PrintPuzzle();
    }

    public static void TestFillWordInvalidNumberChar() {
        char[,] puzzle = new char[,] {
            { '1', '#', '2', '3', '4' },
            { '#', '#', '#', '#', '5' },
            { '6', '7', '#', '8', 'V' },
            { 'W', '#', 'X', 'Y', 'Z' },
        };

        Crossword crossword = new(puzzle);
        Console.WriteLine("Testing invalid inputs:");

        Console.WriteLine("\n0:");
        crossword.FillWord((0, 'h'), "BEE");

        Console.WriteLine("\n9:");
        crossword.FillWord((9, 'v'), "BEE");

        Console.WriteLine("\na:");
        crossword.FillWord((1, 'a'), "BEE");

        Console.WriteLine("\n9 and b:");
        crossword.FillWord((9, 'b'), "BEE");
    }

    public static void TestFillWordWordTooLong() {
        char[,] puzzle = new char[,] {
            { '1', '#', '2', '3', '4' },
            { '#', '#', '#', '#', '5' },
            { '6', '7', '#', '8', 'V' },
            { 'W', '#', 'X', 'Y', 'Z' },
        };

        Crossword crossword = new(puzzle);
        crossword.FillWord((1, 'h'), "FABLED");
        crossword.FillWord((6, 'v'), "BAR");
    }

    //public static void TestIndexer()
    //{
    //    char[,] puzzle = new char[,] {
    //        { '#', '#', '#', '#', '#' },
    //        { '#', '#', '#', '#', '#' },
    //        { '#', '#', '#', '#', '#' },
    //        { '#', '#', '#', '#', '#' },
    //    };

    //    Crossword crossword = new(puzzle);

    //    crossword[0, 0] = '1';
    //    crossword[0, 4] = '2';
    //    crossword[2, 0] = '3';
    //    crossword[3, 3] = '4';

    //    Console.WriteLine(crossword[0, 0]); // 1
    //    Console.WriteLine(crossword[0, 1]); // #
    //    Console.WriteLine(crossword[0, 4]); // 2
    //    Console.WriteLine(crossword[1, 0]); // #
    //    Console.WriteLine(puzzle[2, 0]); // 3
    //}
}
