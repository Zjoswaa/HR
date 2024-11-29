public class Program {
    public static void Main() {
        bool hasAbstractAreaProperty = typeof(Shape).GetProperty("Area").GetAccessors()[0].IsAbstract;
        bool hasAbstractPerimeterProperty = typeof(Shape).GetProperty("Perimeter").GetAccessors()[0].IsAbstract;
        bool hasAbstractInfoMethod = typeof(Shape).GetMethod("Info").IsAbstract;

        Console.WriteLine($"Property Area was declared abstract in Shape: {hasAbstractAreaProperty}");
        Console.WriteLine($"Property Perimeter was declared abstract in Shape: {hasAbstractPerimeterProperty}");
        Console.WriteLine($"Method Info was declared abstract in Shape: {hasAbstractInfoMethod}");

        List<Shape> shapes = new()
        {
            new Square(5),
            new Square(8.3),
            new Circle(6),
            new Circle(7.5),
        };

        foreach (Shape shape in shapes) {
            Console.WriteLine((int)shape.Area);
            Console.WriteLine((int)shape.Perimeter);
            Console.WriteLine(shape.Info());
        }
    }
}
