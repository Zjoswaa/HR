public class Knight : IChessPiece {
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsWhite { get; set; }

    public Knight(int X, int Y, bool IsWhite) {
        this.X = X;
        this.Y = Y;
        this.IsWhite = IsWhite;
    }

    public bool CanMove(int X, int Y) {
        return (Math.Abs(this.X - X) == 2 && Math.Abs(this.Y - Y) == 1) || (Math.Abs(this.X - X) == 1 && Math.Abs(this.Y - Y) == 2);
    }

    public override string ToString() {
        return $"{(IsWhite ? "White" : "Black")} Knight at ({X}, {Y})";
    }
}
