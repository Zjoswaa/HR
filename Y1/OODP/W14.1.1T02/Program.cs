class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "SUMMARY":
                summary(); break;
            case "REMOVE":
                remove(); break;
            case "SINGLE":
                singleproduct(); break;
            default: throw new ArgumentException();
        }
    }

    public static void summary() {
        Inventory inventory = new Inventory();

        inventory.AddProduct("Apple", 0.5, 10);
        inventory.AddProduct("Banana", 0.3, 20);
        inventory.AddProduct("Orange", 0.4, 15);
        inventory.AddProduct("Pear", 0.6);

        Console.WriteLine(inventory.GetInventorySummary());
        // Output: Total products: 45
        //         Total value: $17
    }

    public static void remove() {
        Inventory inventory = new Inventory();

        inventory.AddProduct("Apple", 0.5, 10);
        inventory.AddProduct("Banana", 0.3, 20);
        inventory.AddProduct("Orange", 0.4, 15);
        inventory.AddProduct("Pear", 0.6);

        inventory.RemoveProduct("Banana");

        Console.WriteLine(inventory.GetInventorySummary());
        // Output: Total products: 25
        //         Total value: $11
    }

    public static void singleproduct() {
        Inventory inventory = new Inventory();

        inventory.AddProduct("Apple", 0.5, 10);
        inventory.AddProduct("Banana", 0.3, 20);
        inventory.AddProduct("Orange", 0.4, 15);
        inventory.AddProduct("Pear", 0.6);

        Product apple = inventory.GetProduct("Apple");

        Console.WriteLine(apple);
        // Output: Name: Apple, Price: $0.5, Quantity: 10
    }
}
