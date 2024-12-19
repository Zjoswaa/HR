public class Program {
    public static void Main(string[] args) {
        switch (args[1]) {
            case "GET":
                TestGet(); break;
            case "PRINT":
                TestPrint(); break;
            default: throw new ArgumentException();
        }
    }

    private static void TestGet() {
        Console.WriteLine("=== Testing method GetTestResult ===");
        int[] pointsObtained = new[] { 0, 55, 100 };
        int[] maxPoints = new[] { 100, 200 };
        foreach (int max in maxPoints) {
            foreach (int points in pointsObtained) {
                var result = TestResultProcessor.GetTestResult(points, max);
                TestResultProcessor.PrintTestResult(result);
            }
        }
    }

    private static void TestPrint() {
        Console.WriteLine("=== Testing method PrintTestResult ===");
        ValueTuple<double, bool>[] results = new[] {
            (5.5, true),
            (10.0, true),
            (5.4, false),
            (2.5, false),
        };

        foreach (var result in results) {
            TestResultProcessor.PrintTestResult(result);
        }
    }
}
