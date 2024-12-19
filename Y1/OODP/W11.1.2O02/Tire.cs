class Tire {
    public string Brand { get; }
    private int _durability = 5;
    public int Durability {
        get => _durability;
        private set => _durability = Math.Max(0, value);
    }

    public Tire(string brand) {
        Brand = brand;
    }

    public void Use() {
        Durability--;
    }

    public override string ToString() {
        return $"Brand: {Brand}, Durability: {Durability}";
    }
}
