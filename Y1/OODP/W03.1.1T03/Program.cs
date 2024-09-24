class Program {
    public static void Main() {
        Console.WriteLine("Give the first number:");
        double first = double.Parse(Console.ReadLine());
        Console.WriteLine("Give the first number:");
        double second = double.Parse(Console.ReadLine());

        Console.WriteLine($"{first} + {second} = {Calculator.Add(first, second)}");
        Console.WriteLine($"{first} - {second} = {Calculator.Subtract(first, second)}");
        Console.WriteLine($"{first} * {second} = {Calculator.Multiply(first, second)}");
        Console.WriteLine($"{first} / {second} = {Calculator.Divide(first, second)}");
        Console.WriteLine($"{first} % {second} = {Calculator.Modulo(first, second)}");
    }
}
