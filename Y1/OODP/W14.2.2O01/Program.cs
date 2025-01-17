public static class Program {
    public static void Main() {
        List<Plant> plants = InventoryManager.ReadInventory("inventory.json");

        Console.WriteLine("Items with low inventory:");
        InventoryManager.DetectLowInventory(plants).ForEach(
            p => Console.WriteLine($" - {p.Name} [{p.Stock} in stock]")
        );

        Console.WriteLine("\nLast sold plants:");
        InventoryManager.LastSoldItems(plants).ForEach(
            p => Console.WriteLine($" - {p.Name} ({p.Category}) [Sold on: {p.LastSold.ToString("dd-MM-yyyy")}]")
        );

        Console.WriteLine("\nItems with category [bryophyta]:");
        foreach (Plant p in InventoryManager.SearchByCategory(plants, "bryophyta")) {
            Console.WriteLine($" - {p.Name} ({p.Category}) > Sold: {p.Sell(15)} items");
        }

        Console.WriteLine("\nItems with low inventory in category [bryophyta]:");
        InventoryManager.DetectLowInventory(InventoryManager.SearchByCategory(plants, "bryophyta")).ForEach(
            p => Console.WriteLine($" - {p.Name} [{p.Stock} in stock]")
        );

        Console.WriteLine("\nItems to potentially remove from inventory:");
        InventoryManager.PotentialRemoval(plants).ForEach(
            p => Console.WriteLine(
                $" - {p.Name} ({p.Category}) [{p.Stock} in stock / last sold: {p.LastSold.ToString("dd-MM-yyyy")}]")
        );
    }
}
