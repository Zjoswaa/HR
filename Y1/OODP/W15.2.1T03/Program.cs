public class Program {
    static void Main() {
        ColorValidator.DisplayColors();

        Console.WriteLine("Enter a color:");
        string input = Console.ReadLine();
        ColorValidator.ValidateColor(input);
    }
}
