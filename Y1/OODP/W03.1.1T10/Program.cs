class Program {
    public static void Main() {
        var db = new DbManager();

        Console.WriteLine($"Current connection: {db.Connection}");
    }
}
