class Circle {
    public double Radius;

    public Circle(double Radius) {
        this.Radius = Radius;
    }

    public double Area() {
        return Math.PI * Math.Pow(this.Radius, 2);
    }
}
