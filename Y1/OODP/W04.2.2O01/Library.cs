class Library {
    public List<Book> Books;

    public Library() {
        this.Books = [];
    }

    public Library(List<Book> Books) {
        this.Books = Books;
    }

    public void AddBook(Book Book) {
        this.Books.Add(Book);
    }

    public void AddBook(int ID, string Title) {
        this.Books.Add(new Book(ID, Title));
    }

    public Book FindBook(int ID) {
        foreach (Book Book in this.Books) {
            if (Book.ID == ID) {
                return Book;
            }
        }
        return null;
    }

    public Book FindBook(string ID) {
        try {
            foreach (Book Book in this.Books) {
                if (Book.ID == int.Parse(ID)) {
                    return Book;
                }
            }
        } catch (FormatException e) {
            Console.WriteLine($"ID = {ID}: invalid. {e.Message}");
        }
        return null;
    }
}
