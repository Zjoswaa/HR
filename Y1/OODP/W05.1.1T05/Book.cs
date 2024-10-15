public class Book {
    public string Title;
    public string Author { get; set; }
    public int Pages;
    public string ISBN;

    public Book(string title, string author, int pages, string isbn) {
        Title = title;
        Author = author;
        Pages = pages;
        ISBN = isbn;
    }

    public override string ToString() {
        return $"{Title} by {Author}. ISBN:{ISBN}, {Pages} pages.";
    }
}
