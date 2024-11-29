public abstract class ChessPiece {
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsWhite { get; set; }
    
    public ChessPiece(int X, int Y, bool IsWhite) {
        this.X = X;
        this.Y = Y;
        this.IsWhite = IsWhite;
    }

    public abstract bool CanMove(int X, int Y);
}
