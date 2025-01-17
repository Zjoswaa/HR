public class Program {
    static void Main(string[] args) {
        // Get a lambda that calculates the unscaled distance
        var distanceCalculator = Point.GetDistanceCalculator(1.0);

        // Get a lambda that calculates the distance scaled by a factor of 0.5
        var halfDistanceCalculator = Point.GetDistanceCalculator(0.5);

        // Use the lambdas to calculate distances between points
        Point p1 = new(0, 0);
        Point p2 = new(3, 4);
        double unscaledDistance = distanceCalculator(p1, p2); // Returns 5.0
        double halfScaledDistance = halfDistanceCalculator(p1, p2); // Returns 2.5

        Console.WriteLine("Unscaled distance: " + unscaledDistance);
        Console.WriteLine("Half-scaled distance: " + halfScaledDistance);
    }
}
