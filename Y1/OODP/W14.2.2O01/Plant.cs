using System.Globalization;

public class Plant : IComparable<Plant> {
    public string Name { get; set; }
    public string Category { get; set; }
    private int _stock;
    public int Stock {
        get {
            return _stock;
        }
        set {
            _stock = value;
        }
    }
    public DateOnly LastSold { get; set; }

    public Plant(string name, string category, int stock, string lastSold) {
        Name = name;
        Category = category;
        _stock = stock;
        LastSold = DateOnly.ParseExact(lastSold, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    }

    public int CompareTo(Plant other) {
        return other == null ? 1 : Stock.CompareTo(other.Stock);
    }

    public int Sell(int amount) {
        int AmountToSell = Math.Min(amount, Stock);
        Stock -= AmountToSell;
        LastSold = DateOnly.FromDateTime(DateTime.Now);
        return AmountToSell;
    }
}
