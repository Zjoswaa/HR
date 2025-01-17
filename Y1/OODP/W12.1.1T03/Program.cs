class Program {
    static void Main() {
        Console.Write("Number: ");
        int Num = Convert.ToInt32(Console.ReadLine());
        Console.Write("Base: ");
        int Base = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(RecursiveLog(Num, Base));
    }

    static int RecursiveLog(int num, int logBase) {
        if (num < logBase) {
            return 0;
        }

        return 1 + RecursiveLog(num / logBase, logBase);
    }
}
