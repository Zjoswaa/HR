public class Program {
    public static void Main() {
        Range range1 = new(0, 10, 1);
        PrintRange(range1);
        Console.WriteLine();

        Range range2 = new(5, 20, 3);
        PrintRange(range2);
        Console.WriteLine();

        Range range3 = new(-10, 11, 5);
        PrintRange(range3);
    }

    private static void PrintRange(Range range) {
        foreach (int i in range.Next()) {
            Console.Write($"{i} ");
        }
    }
}
