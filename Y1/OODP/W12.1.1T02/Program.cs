class Program {
    static void Main() {
        Console.Write("Number: ");
        int Input = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Factorial(Input));
    }

    static int Factorial(int n) {
        if (n <= 0) {
            return -1;
        }
        if (n == 1) {
            return 1;
        }

        return n * Factorial(n - 1);
    }
}
