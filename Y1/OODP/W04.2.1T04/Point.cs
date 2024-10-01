class Point {
    public double X;
    public double Y;

    public Point(double X, double Y) {
        this.X = X;
        this.Y = Y;
    }

    public Point() {
        this.X = 0;
        this.Y = 0;
    }

    public Point(Point Point) {
        this.X = Point.X;
        this.Y = Point.Y;
    }

    public static double EuclideanDistance(Point p, Point q) {
        return Math.Sqrt(Math.Pow(p.X - q.X, 2) + Math.Pow(p.Y - q.Y, 2));
    }
}
