class Square : Shape {
    public double Length { get; set; }
    public override double Area {
        get {
            return this.Length * this.Length;
        }
    }
    public override double Perimeter {
        get {
            return 4 * this.Length;
        }
    }

    public Square(double Length) {
        this.Length = Length;
    }

    public override string Info() {
        return $"Square with sides of {Length}";
    }
}
