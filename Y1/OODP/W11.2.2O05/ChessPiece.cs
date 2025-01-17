public abstract class ChessPiece {
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsWhite { get; set; }
    public abstract string Symbol { get; }

    public ChessPiece(int X, int Y, bool IsWhite) {
        this.X = X;
        this.Y = Y;
        this.IsWhite = IsWhite;
    }

    public virtual bool CanMove(int X, int Y) {
        return X >= 0 && X <= 7 && Y >= 0 && Y <= 7;
    }

    public override string ToString() {
        return $"{(IsWhite ? "White" : "Black")} {base.ToString()} at ({X}, {Y})";
    }
}
