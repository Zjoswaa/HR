public class Point {
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y) {
        X = x;
        Y = y;
    }

    // GetDistanceCalculator goes here
    public static Func<Point, Point, double> GetDistanceCalculator(double scale) {
        return (p1, p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)) * scale;
    }
}
