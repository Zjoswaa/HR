static class Program {
    static void Main() {
        Console.Write("Input a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        long result = Fibonacci.Calculate(n);

        Console.WriteLine($"Fibonacci.Calculate({n}) = {result}");
    }
}
