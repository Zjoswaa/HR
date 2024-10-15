class Book : Publication {
    public string ISBN { get; }
    public string Author { get; }
    public double Price { get; private set; }
    public string Currency { get; private set; } = "EUR";

    public Book(string ISBN, string Title, string Publisher, int Pages, string Author, List<string> Audience, double Price)
        : base(Title, Publisher, "Book", Pages, Audience) {
        this.ISBN = ISBN;
        this.Author = Author;
        this.Price = Price;
    }

    public bool IsSuitableForChild() {
        return this.Audience.Contains("Children");
    }

    public void SetPriceAndCurrency(double Price, string Currency) {
        if (Price <= 0) {
            return;
        }
        this.Price = Price;
        this.Currency = Currency;
    }

    public override string ToString() {
        return $"{Author}, ISBN: {ISBN}, {Title}, {Pages} pages, {this._publicationDate.ToString("yyyy-MM-dd")}, {Currency} {(int)Math.Floor(Price)}";
    }
}
