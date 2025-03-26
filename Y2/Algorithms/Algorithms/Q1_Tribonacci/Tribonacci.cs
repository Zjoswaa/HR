namespace Solution;

public class Q1 {
    public static long Tribonacci(long n, long[] mem) {
        Utils.ShowCallStack(false);
        //ToDo 1: Tribonacci via Dynamic programming 
        if (mem == null || mem.Length <= n) {
            mem = new long[n + 1];
            if (n >= 0) mem[0] = 0;
            if (n >= 1) mem[1] = 0;
            if (n >= 2) mem[2] = 1;
        }
        
        if (mem[n] != 0 || (n >= 0 && n <= 2)) {
            return mem[n];
        }
        
        mem[n] = Tribonacci(n - 1, mem) + Tribonacci(n - 2, mem) + Tribonacci(n - 3, mem);
        return mem[n];
    }
}
