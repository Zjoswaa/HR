class Product : IEquatable<Product>, IComparable<Product> {
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public Product(string Name, int Price, int Quantity) {
        this.Name = Name;
        this.Price = Price;
        this.Quantity = Quantity;
    }

    public bool Equals(Product? Product) {
        if (Product is null) {
            return false;
        }
        return this.Name == Product.Name;
    }

    public int CompareTo(Product? Product) {
        if (this.Price == Product.Price) {
            return String.Compare(this.Name, Product.Name, StringComparison.Ordinal);
        }
        if (this.Price < Product.Price) {
            return -1;
        }
        return 1;
    }

    public static bool operator ==(Product p1, Product p2) {
        if (p1 is null || p2 is null) {
            return p1 is null && p2 is null;
        }
        return p1.Equals(p2);
    }

    public static bool operator !=(Product p1, Product p2) {
        return !(p1 == p2);
    }

    public override bool Equals(object? obj) {
        return obj is Product product && this.Equals(product);
    }

    public override string ToString() {
        return $"{Name} ({Price} x {Quantity})";
    }
}
