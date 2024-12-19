class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Overload":
                TestOperatorOverload();
                return;
            case "Where":
                TestWhereConstraints();
                return;
            default: throw new ArgumentOutOfRangeException();
        }
    }

    static void TestOperatorOverload() {
        Player player1 = new("Cassia", 20);
        Player player2 = new("Xul", 15);
        Player player3 = new("Isendra", 10);

        Console.WriteLine($"player1 > player2 ? " + (player1 > player2)); //true
        Console.WriteLine($"player2 > player3 ? " + (player2 > player3)); //true
        Console.WriteLine($"player3 > player1 ? " + (player3 > player1)); //false

        Console.WriteLine();

        Console.WriteLine($"player1 < player2 ? " + (player1 < player2)); //false
        Console.WriteLine($"player2 < player3 ? " + (player2 < player3)); //false
        Console.WriteLine($"player3 < player1 ? " + (player3 < player1)); //true
    }

    static void TestWhereConstraints() {
        Player player = new("Isendra", 10);
        Enemy enemy = new("Skeleton", 20, new List<Item>() {
            new Item("Mace"),
            new Item("Helmet"),
        });
        Crate crate = new(new List<Item>() {
            new Item("Apple"),
            new Item("Dagger"),
        });

        while (!enemy.IsLootable) {
            player.Attack(enemy);
        }
        player.Attack(crate);

        Console.WriteLine("Obtained loot:");
        foreach (Item item in player.Inventory) {
            Console.WriteLine($"- {item.Name}");
        }
    }
}
