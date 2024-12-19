public class Program {
    public static void Main() {
        List<Book> books = new() {
            new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925),
            new Book("The Catcher in the Rye", "J.D. Salinger", 1951),
            new Book("Moby-Dick", "Herman Melville", 1851),
            new Book("Mrs. Dalloway", "Virginia Woolf", 1925),
            new Book("The Adventures of Huckleberry Finn", "Mark Twain", 1884),
            new Book("The Old Man and the Sea", "Ernest Hemingway", 1952),
            new Book("The Old Man and the Sea (Illustrated Edition)", "Ernest Hemingway", 1952),
            new Book("The Great Gatsby (Illustrated Edition)", "F. Scott Fitzgerald", 1925)
        };

        books.Sort();

        foreach (var book in books) {
            Console.WriteLine($"{book.Title} by {book.Author} ({book.Year})");
        }

    }
}
