using Newtonsoft.Json;

public static class InventoryManager {
    public static List<Plant> ReadInventory(string dataset) {
        string jsonString = File.ReadAllText(dataset);
        return JsonConvert.DeserializeObject<List<Plant>>(jsonString)!;
    }

    public static List<Plant> DetectLowInventory(List<Plant> Inventory) {
        return Inventory.Where(p => p.Stock < 5).OrderBy(p => p.Stock).ToList();
    }

    public static List<Plant> SearchByCategory(List<Plant> Inventory, string Category) {
        return Inventory.Where(p => p.Category == Category).ToList();
    }

    public static List<Plant> LastSoldItems(List<Plant> Inventory) {
        return Inventory.Where(p => p.LastSold == Inventory.MaxBy(p => p.LastSold).LastSold).ToList();
    }

    public static List<Plant> PotentialRemoval(List<Plant> Inventory) {
        return Inventory.Where(p => (DateTime.Now - p.LastSold.ToDateTime(new TimeOnly(0, 0, 0))).Days > 365 && p.Stock > 10).ToList();
    }
}
