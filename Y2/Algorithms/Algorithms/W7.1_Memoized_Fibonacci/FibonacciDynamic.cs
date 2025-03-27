namespace Solution;

public static class DynamicProgramming {

    public static long FibonacciDynamic(long n, long[] storedResults) {
        Utils.ShowCallStack(false); //DO NOT comment this line of code

        if (storedResults is null || storedResults.Length <= n) {
            storedResults = new long[n + 1];
            if (n >= 0) storedResults[0] = 0;
            if (n >= 1) storedResults[1] = 1;
        }

        if (storedResults[n] != 0 || n == 0 || n == 1) {
            return storedResults[n];
        }
        
        storedResults[n] = FibonacciDynamic(n - 1, storedResults) + FibonacciDynamic(n - 2, storedResults);
        return storedResults[n];
    }
}
