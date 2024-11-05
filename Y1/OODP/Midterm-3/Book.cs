class Book : Publication {
    public string Author { get; }
    public int AmountAvailable { get; private set; }

    public Book(string author, string title, int amountAvailable) : base(title) {
        Author = author;
        AmountAvailable = amountAvailable;
    }

    public override void Borrow() {
        if (AmountAvailable >= 1) {
            Console.WriteLine($"{Title} is available: {AmountAvailable} left");
            AmountAvailable--;
            UpdateStatus();
        } else {
            Console.WriteLine($"{Title} is not available");
        }
    }

    public override void UpdateStatus() {
        if (AmountAvailable >= 1) {
            Status = "Available";
        } else {
            Status = "Borrowed";
        }
    }
}
