class Vector2D {
    public double X { get; }
    public double Y { get; }

    public Vector2D(double x, double y) {
        X = x;
        Y = y;
    }

    public static Vector2D operator +(Vector2D v1, Vector2D v2) {
        // Add the X's together, and the Y's together. Then return a new Vector.
        return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
    }

    public override string ToString() => $"({X}, {Y})";
}
