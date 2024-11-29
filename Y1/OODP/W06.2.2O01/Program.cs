public class Program {
    public static void Main() {
        Console.WriteLine("ChessPiece is an abstract class: " +
            (typeof(ChessPiece).IsAbstract && !typeof(ChessPiece).IsInterface));
        Console.WriteLine();

        Knight whiteKnight = new(2, 1, true);
        Knight blackKnight = new(7, 8, false);
        PrintCanPieceMoveTo(whiteKnight, 1, 3);
        PrintCanPieceMoveTo(whiteKnight, 4, 2);
        PrintCanPieceMoveTo(whiteKnight, 4, 3);
        PrintCanPieceMoveTo(blackKnight, 6, 6);
        PrintCanPieceMoveTo(blackKnight, 5, 7);
        PrintCanPieceMoveTo(blackKnight, 8, 8);
    }

    private static void PrintCanPieceMoveTo(ChessPiece piece, int x, int y) {
        Console.WriteLine(piece.ToString() + $" can move to ({x}, {y}): " + piece.CanMove(x, y));
    }
}
