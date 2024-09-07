class Program {
    static void Main() {
        var pack = new List<string>() {
            "laptop",
            "lunch",
            "notebook",
            "pen",
        };

        Console.WriteLine($"The first item in the pack is a " + pack[0]);
        Console.WriteLine($"The last item in the pack is a " + pack[^1]);
    }
}
