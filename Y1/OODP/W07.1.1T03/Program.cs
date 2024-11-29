public class Program {
    public static void Main() {
        var res1 = Converter.ConvertVariables<int, string>(5);
        var res2 = Converter.ConvertVariables<bool, int>(true);
        var res3 = Converter.ConvertVariables<double, int>(12.5);

        Console.WriteLine(res1);
        Console.WriteLine(res2);
        Console.WriteLine(res3);
    }
}
