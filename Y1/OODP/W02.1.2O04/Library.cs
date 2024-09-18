class Library {
    public List<Book> Books;
    public int MaxSize;

    public Library(int MaxSize) {
        this.MaxSize = MaxSize;
        this.Books = new();
    }

    public bool AddBook(int ID, string Title) {
        if (this.Books.Count == MaxSize) {
            return false;
        }
        this.Books.Add(new Book(ID, Title));
        return true;
    }

    public Book FindBookByID(int ID) {
        foreach (Book book in this.Books) {
            if (book.ID == ID) {
                return book;
            }
        }
        return null;
    }

    public void EditBookTitle(int ID, string NewTitle) {
        foreach(Book book in this.Books) {
            if (book.ID == ID) {
                book.Title = NewTitle;
                return;
            }
        }
    }

    public void RemoveBookByTitle(string Title) {
        this.Books.RemoveAll(b => b.Title == Title);
    }
}
