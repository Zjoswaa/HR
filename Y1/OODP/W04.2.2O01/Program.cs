class Program {
    public static void Main() {
        TestBook();
        TestLibrary();
    }

    private static void TestBook() {
        Console.WriteLine("===Testing Book class===");
        Book book1 = new(10, "Introduction to C#");
        Book book2 = new(11, "Advanced C# Programming");
        Book book3 = new(12);
        foreach (var book in new Book[] { book1, book2, book3 }) {
            Console.WriteLine(book.Info());
        }
    }

    private static void TestLibrary() {
        Console.WriteLine("\n===Testing Library class===");
        Library HRLib = new();
        Console.WriteLine("Testing adding books");
        HRLib.AddBook(1, "The Art of Computer Programming");
        HRLib.AddBook(2, "Design Patterns");
        HRLib.AddBook(3, "Clean Code");
        HRLib.AddBook(4, "Code Complete");
        HRLib.AddBook(5, "Programming Pearls");
        Console.WriteLine($"Added {HRLib.Books.Count} books successfully");

        Console.WriteLine("\nTesting FindBook with int ID");
        Book lookup;
        for (int i = 0; i <= 6; i++) {
            lookup = HRLib.FindBook(i);
            Console.WriteLine(lookup != null
                ? lookup.Info()
                : $"ID = {i}: not found");
        }

        Console.WriteLine("\nTesting FindBook with string ID");
        foreach (var idString in new string[] { "3", "04", "Five" }) {
            lookup = HRLib.FindBook(idString);
            Console.WriteLine(lookup != null
                ? lookup.Info()
                : $"ID = {idString}: not found");
        }
    }
}
