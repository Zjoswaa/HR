﻿static class TestResultProcessor {
    public static Tuple<double, bool> GetTestResult(int points, int maxPoints) {
        double Grade = (double)points / maxPoints * 10;
        return Tuple.Create(Grade, Grade >= 5.5);
    }

    public static void PrintTestResult(Tuple<double, bool> result) {
        Console.WriteLine($"Grade: {result.Item1}");
        Console.WriteLine(result.Item2 ? "Passed" : "Did not pass");
    }
}