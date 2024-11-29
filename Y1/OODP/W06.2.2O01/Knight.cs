public class Knight : ChessPiece {
    public Knight(int X, int Y, bool IsWhite) : base(X, Y, IsWhite) { }

    public override bool CanMove(int X, int Y) {
        return (Math.Abs(this.X - X) == 2 && Math.Abs(this.Y - Y) == 1) || (Math.Abs(this.X - X) == 1 && Math.Abs(this.Y - Y) == 2);
    }

    public override string ToString() {
        return $"{(IsWhite ? "White" : "Black")} Knight at ({X}, {Y})";
    }
}
