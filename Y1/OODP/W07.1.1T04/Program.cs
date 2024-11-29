public class Program {
    public static void Main() {
        KeyValuePair<string, string> translation = new("one", "een");
        KeyValuePair<string, double> examResult = new("012345", 6.5);
        KeyValuePair<string, List<double>> examResults =
                new("012345",
                new List<double>() { 8.3, 5.2, 6.5 }
            );

        PrintPair(translation);
        PrintPair(examResult);
        PrintPair(examResults);
    }

    private static void PrintPair<T1, T2>(KeyValuePair<T1, T2> pair) {
        Console.WriteLine($"{pair.Key}: {pair.Value}");
    }
}
