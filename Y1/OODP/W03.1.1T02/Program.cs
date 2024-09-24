class Program {
    static void Main() {
        Scale scale = new Scale();
        Console.WriteLine(scale.DisplayWeight(60));

        scale.UseKg = false;
        Console.WriteLine(scale.DisplayWeight(60));
    }
}
