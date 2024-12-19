public class Book : IHasID {
    public int ID { get; set; }
    private static int _number;
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author) {
        Title = title;
        Author = author;
        ID = ++_number;
    }
}
