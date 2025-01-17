static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Test1":
                Test1();
                return;
            case "Test2":
                Test2();
                return;
            case "All":
                Test1();
                Test2();
                return;
            default: throw new ArgumentException();
        }
    }

    public static void Test1() {
        Item<string> root =
            new("1", new List<Item<string>>() {
                    new("1.1", new List<Item<string>>() {
                        new("1.1.1"),
                        new("1.1.2"),
                    }),
                    new("1.2", new List<Item<string>>() {
                        new("1.2.1"),
                        new("1.2.2"),
                        new("1.2.3"),
                    }),
                    new("1.3", new List<Item<string>>() {
                        new("1.3.1"),
                    }),
                    new("1.4")
                }
            );

        Console.WriteLine("Entire structure:");
        TopDown.Display(root);

        foreach (string key in new string[] { "1", "1.1", "1.2.2", "1.4", "None" }) {
            var x = TopDown.Find(root, key);
            Console.WriteLine($"Key {key} has the following subitems:");
            TopDown.Display(x);
        }
    }

    public static void Test2() {
        Item<string> root =
            new("2", new List<Item<string>>() {
                    new("2.1"),
                    new("2.2", new List<Item<string>>() {
                        new("2.2.1"),
                        new("2.2.2"),
                        new("2.2.3"),
                    }),
                    new("2.3"),
                    new("2.3.1")
                }
            );

        Console.WriteLine("Entire structure:");
        TopDown.Display(root);

        foreach (string key in new string[] { "None", "2", "2.1", "2.2.2", "2.3", }) {
            var x = TopDown.Find(root, key);
            Console.WriteLine($"Key {key} has the following subitems:");
            TopDown.Display(x);
        }
    }
}
