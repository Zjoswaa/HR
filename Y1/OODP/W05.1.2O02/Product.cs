class Product {
    public string Name;
    public double Price;
    public int Stock;

    public Product(string Name, double Price, int Stock) {
        this.Name = Name;
        this.Price = Price;
        this.Stock = Stock;
    }

    public virtual void Sell(int Units) {
        if (Stock < Units) {
            Console.WriteLine($"{Name} is out of stock");
            return;
        }
        Stock -= Units;
        Console.WriteLine($"Sold {Units} units of {Name}");
    }

    public override string ToString() {
        return $"Name: {Name}; price: {Price}; stock: {Stock}";
    }
}
