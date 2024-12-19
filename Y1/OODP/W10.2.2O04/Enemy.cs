class Enemy : IAttackable, ILootable {
    public string Name { get; }
    public int HitPoints { get; private set; }
    public bool IsLootable { get; private set; } = false;
    public List<Item> Items { get; private set; }

    public Enemy(string name, int hitPoints, List<Item> items) {
        Name = name;
        HitPoints = hitPoints;
        Items = items;
    }

    public void IsAttacked(int damage) {
        Console.WriteLine($"{Name} takes {damage} damage!");
        HitPoints -= damage;
        HitPoints = HitPoints < 0 ? 0 : HitPoints;
        IsLootable = HitPoints == 0;
    }

    public List<Item> IsLooted() {
        List<Item> loot = new();
        if (!IsLootable)
            return loot; // Return an empty list if not lootable

        Console.WriteLine($"The {Name} was looted!");
        loot.AddRange(Items);
        Items.Clear();
        return loot;
    }
}
