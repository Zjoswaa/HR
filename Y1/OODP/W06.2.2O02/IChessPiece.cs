interface IChessPiece {
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsWhite { get; set; }

    public bool CanMove(int X, int Y);
}
