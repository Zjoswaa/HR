public class Book : IComparable<Book> {
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, int year) {
        Title = title;
        Author = author;
        Year = year;
    }

    public int CompareTo(Book? other) {
        if (other == null) {
            return 1;
        }
        int YearComparison = this.Year.CompareTo(other.Year);
        if (YearComparison != 0) {
            return YearComparison;
        }

        int AuthorComparison = this.Author.CompareTo(other.Author);
        if (AuthorComparison != 0) {
            return AuthorComparison;
        }

        int TitleComparison = this.Title.CompareTo(other.Title);
        if (TitleComparison != 0) {
            return TitleComparison;
        }

        return 0;
    }
}
