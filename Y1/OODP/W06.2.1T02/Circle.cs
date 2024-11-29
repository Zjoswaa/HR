class Circle : Shape {
    public double Radius { get; set; }
    public override double Area {
        get {
            return Math.PI * (this.Radius * this.Radius);
        }
    }
    public override double Perimeter {
        get {
            return 2 * Math.PI * Radius;
        }
    }

    public Circle(double Radius) {
        this.Radius = Radius;
    }

    public override string Info() {
        return $"Circle with a radius of {Radius}";
    }
}
