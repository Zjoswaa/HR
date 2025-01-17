class Board {
    public ChessPiece?[,] Pieces = new ChessPiece?[8, 8] {
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
        { null, null, null, null, null, null, null, null },
    };

    public void PlacePiece(ChessPiece Piece) {
        Pieces[Piece.Y, Piece.X] = Piece;
    }

    public void MovePiece(ChessPiece Piece, int X, int Y) {
        if (Piece.CanMove(X, Y)) {
            Pieces[Piece.Y, Piece.X] = null;
            Piece.X = X;
            Piece.Y = Y;
            Pieces[Y, X] = Piece;
        }
    }
}
