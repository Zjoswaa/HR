class Inventory {
    private Dictionary<string, Product> _products = new();

    public void AddProduct(string name, double price, int quantity) {
        _products[name] = new Product(name, price, quantity);
    }

    public void AddProduct(string name, double price) {
        _products[name] = new Product(name, price, 0);
    }

    public void RemoveProduct(string name) {
        _products.Remove(name);
    }

    public Product GetProduct(string name) {
        return _products[name];
    }

    public string GetInventorySummary() {
        return $"Total products: {_products.Sum(kvp => kvp.Value.Quantity)}\nTotal value: ${Math.Round(_products.Sum(kvp => kvp.Value.Price * kvp.Value.Quantity), 2)}";
    }
}
