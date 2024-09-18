class Book {
    public int ID;
    public string Title;

    public Book(int ID, string Title) {
        this.ID = ID;
        this.Title = Title;
    }

    public string Info() {
        return $"ID: {this.ID}, Title: {this.Title}";
    }
}
