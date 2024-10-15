class Program {
    public static void Main() {
        var shapes = new List<Rectangle>() {
            new Rectangle(4, 5),
            new Rectangle(1, 12),
            new Cuboid(4, 1, 6),
            new Cuboid(3, 3, 3),
        };

        foreach (var shape in shapes) {
            Console.WriteLine(shape.Info());
            Console.WriteLine($"Area: {shape.Area()}");
            Console.WriteLine($"Perimeter: {shape.Perimeter()}");
            if (shape is Cuboid)
                Console.WriteLine($"Volume: {((Cuboid)shape).Volume()}");
            Console.WriteLine();
        }
    }
}
