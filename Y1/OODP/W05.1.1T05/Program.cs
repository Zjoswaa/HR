public class Program {
    public static void Main() {
        List<Book> books = new()
        {
            new Book("Moby-Dick", "Herman Melville", 704, "9781451688386"),
            new Book("The Great Gatsby", "F. Scott Fitzgerald", 180, "9780743273565"),
            new Book("The Catcher in the Rye", "J.D. Salinger", 277, "9780316769488"),
            new Book("The Adventures of Huckleberry Finn", "Mark Twain", 216, "9780142437230"),
        };

        foreach (var book in books)
            Console.WriteLine(book.ToString());
    }
}
