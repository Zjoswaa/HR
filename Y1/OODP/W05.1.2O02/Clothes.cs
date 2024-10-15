class Clothes : Product {
    public string Size;
    public string Material;

    public Clothes(string Name, double Price, int Stock, string Size, string Material) : base(Name, Price, Stock) {
        this.Size = Size;
        this.Material = Material;
    }

    public override void Sell(int Units) {
        base.Sell(Units);
        Console.WriteLine(WashingInstructions());
    }

    private string WashingInstructions() {
        switch (Material) {
            case "Cotton":
                return "Gentle";
            case "Wool":
                return "Hand";
            case "Linen":
                return "Washing machine";
            default:
                return "Unknown";
        }
    }

    public override string ToString() {
        return base.ToString() + $"; size: {Size}; material: {Material}";
    }
}
