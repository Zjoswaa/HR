class Rectangle {
    public int Length, Width;

    public Rectangle(int length, int width) {
        Length = length;
        Width = width;
    }

    public virtual int Area() => Length * Width;
    public virtual int Perimeter() => 2 * Length + 2 * Width;

    public virtual string Info() => $"Length: {Length}; Width: {Width}";
}
