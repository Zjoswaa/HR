class Program {
    public static void Main() {
        Square square1 = new(5);
        Square square2 = new(10);
        Console.WriteLine($"Side: {square1.Side}");
        Console.WriteLine($"Area: {square1.Area()}");
        Console.WriteLine($"Perimeter: {square1.Perimeter()}");
        Console.WriteLine($"Side: {square2.Side}");
        Console.WriteLine($"Area: {square2.Area()}");
        Console.WriteLine($"Perimeter: {square2.Perimeter()}");
    }
}
