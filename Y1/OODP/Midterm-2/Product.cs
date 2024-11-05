class Product {
    public virtual string Name { get; }
    public int Price { get; protected set; }

    public Product(string name, int price) {
        Name = name;
        Price = price;
    }

    public Product(string name) {
        Name = name;
        Price = 0;
    }

    public virtual void ApplyDiscount() {
        Price = (int)Math.Floor((double)Price * 0.9);
    }

    public void ApplyDiscount(double discountRate) {
        Price = (int)Math.Floor((double)Price * (1.0 - discountRate));
    }
}
