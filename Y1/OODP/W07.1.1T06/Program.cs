public class Program {
    public static void Main() {
        Container<int> example1 = new(5);
        Container<string> example2 = new("Hello, World!");
        Container<List<double>> example3 = new(new() { 1, 2.5 });
        Container<bool> example4 = new(true);

        Console.WriteLine(example1.Value);
        Console.WriteLine(example2.Value);
        Console.WriteLine(example3.Value);
        Console.WriteLine(example4.Value);

        example1.ResetValue();
        example2.ResetValue();
        example3.ResetValue();
        example4.ResetValue();
        Console.WriteLine(example1.Value);
        Console.WriteLine(example2.Value);
        Console.WriteLine(example3.Value);
        Console.WriteLine(example4.Value);
    }
}
