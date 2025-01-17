class Program {
    public static void Main() {
        Console.Write("Number: ");
        int Input = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(RecursiveSum(Input));
    }

    static int RecursiveSum(int n) {
        if (n < 0) {
            return 0;
        }
        return n + RecursiveSum(n - 1);
    }
}
