class Cuboid : Rectangle {
    public int Height;

    public Cuboid(int length, int width, int height) : base(length, width) {
        Height = height;
    }

    public int Volume() {
        return Length * Width * Height;
    }

    public override int Area() {
        return 2 * (Length * Width + Length * Height + Width * Height);
    }

    public override int Perimeter() {
        return 4 * (Length + Width + Height);
    }

    public override string Info() {
        return base.Info() + $"; Height: {Height}";
    }
}
