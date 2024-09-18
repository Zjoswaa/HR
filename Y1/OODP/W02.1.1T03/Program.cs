class Program {
    public static void Main() {
        Console.Write("First name: ");
        string FirstName = Console.ReadLine();
        Console.Write("Last name: ");
        string LastName = Console.ReadLine();
        DisplayName(FirstName, LastName);
    }

    public static string Name(string FirstName, string LastName) => $"{FirstName} {LastName}";
    public static void DisplayName(string FirstName, string LastName) => Console.WriteLine(Name(FirstName, LastName));
}
