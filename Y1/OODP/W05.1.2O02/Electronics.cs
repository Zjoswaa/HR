class Electronics : Product {
    public string Brand;
    public string Model;
    private const int _minimumStock = 10;

    public Electronics(string Name, double Price, int Stock, string Brand, string Model) : base(Name, Price, Stock) {
        this.Brand = Brand;
        this.Model = Model;
    }

    public override void Sell(int Units) {
        base.Sell(Units);
        this.Restock();
    }

    private void Restock() {
        this.Stock = _minimumStock;
    }

    public override string ToString() {
        return $"Name: {Name} ({Brand} {Model}); price: {Price}; stock: {Stock}";
    }
}
