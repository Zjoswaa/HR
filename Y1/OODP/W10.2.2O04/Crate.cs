class Crate : IAttackable, ILootable {
    public bool IsLootable { get; private set; }
    public List<Item> Items { get; private set; } = new();

    public Crate(List<Item> items) => Items = items;

    public void IsAttacked(int damage) {
        Console.WriteLine("*Crack*!");
        IsLootable = true;
    }

    public List<Item> IsLooted() {
        Console.WriteLine($"The {ToString()} was looted!");
        List<Item> loot = new(Items);
        Items.Clear();
        return loot;
    }
}
