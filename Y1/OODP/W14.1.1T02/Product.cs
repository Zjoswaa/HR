class Product {
    public string Name { get; }
    public double Price { get; }
    public int Quantity { get; }

    public Product(string Name, double Price, int Quantity) {
        this.Name = Name;
        this.Price = Price;
        this.Quantity = Quantity;
    }

    public override string ToString() {
        return $"{this.Name}, Price: ${this.Price}, Quantity: {this.Quantity}";
    }
}
