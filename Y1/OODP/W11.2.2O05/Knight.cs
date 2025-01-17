public class Knight : ChessPiece {
    public Knight(int X, int Y, bool IsWhite) : base(X, Y, IsWhite) { }

    public override string Symbol {
        get {
            return $"{(IsWhite ? "W" : "B")}Kn";
        }
    }

    public override bool CanMove(int X, int Y) {
        return base.CanMove(X, Y) && (Math.Abs(this.X - X) == 2 && Math.Abs(this.Y - Y) == 1) || (Math.Abs(this.X - X) == 1 && Math.Abs(this.Y - Y) == 2);
    }
}
