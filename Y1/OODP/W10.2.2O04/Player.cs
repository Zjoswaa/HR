class Player {
    public string Name { get; }
    public int AttackPower { get; }
    public List<Item> Inventory = new();

    public Player(string name, int attackPower) {
        Name = name;
        AttackPower = attackPower;
    }

    public void Attack<T>(T target) where T : IAttackable, ILootable {
        if (target is Crate) {
            Console.WriteLine($"{Name} attacks Crate");
        } else {
            Console.WriteLine($"{Name} attacks Enemy");
        }
        target.IsAttacked(AttackPower);
        foreach (Item item in target.IsLooted()) {
            Inventory.Add(item);
        }
    }

    public static bool operator <(Player p1, Player p2) {
        if (p1 is null || p2 is null) {
            return p1 is null && p2 is null;
        }
        return p1.AttackPower < p2.AttackPower;
    }

    public static bool operator >(Player p1, Player p2) {
        if (p1 is null || p2 is null) {
            return p1 is null && p2 is null;
        }
        return p1.AttackPower > p2.AttackPower;
    }
}
