class Program {
    public static void Main() {
        PrintFullName("John", "Doe");
    }

    public static void PrintFullName(string firstName, string lastName) {
        Console.WriteLine($"{firstName} {lastName}");
    }
}
