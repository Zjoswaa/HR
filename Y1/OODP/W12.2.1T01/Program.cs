public class Program {
    static void Main() {
        Console.Write("What is n? ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Fibonacci({n}) = " + Fibonacci(n));
    }

    static int Fibonacci(int n) {
        if (n <= 1) {
            return n;
        }

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
