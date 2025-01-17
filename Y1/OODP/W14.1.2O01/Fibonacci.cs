static class Fibonacci {
    private static Dictionary<int, long> Results = new() {{0, 0}, {1, 1}};
    
    public static long Calculate(int n) {
        if (!Results.ContainsKey(n)) {
            Results[n] = Calculate(n - 1) + Calculate(n - 2);
        }
        return Results[n];
    }
}
