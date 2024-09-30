public class Book {
    public readonly string Title;
    public readonly string Author;
    public readonly int PublicationYear;

    public Book(string Title, string Author, int PublicationYear) {
        this.Title = Title;
        this.Author = Author;
        this.PublicationYear = PublicationYear;
    }

    public override string? ToString() {
        return $"{this.Title} by {this.Author} ({this.PublicationYear})";
    }
}
