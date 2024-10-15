public class Program {
    public static void Main() {
        Shop shop = new(new List<string>() { "Bread", "Egg" });
        List<string> shoppingBag = new();

        shoppingBag.Add(shop.Buy("Bread"));

        if (shop.HaveInInventory("Egg")) {
            for (int i = 0; i < 12; i++) {
                shoppingBag.Add(shop.Buy("Egg"));
            }
        }

        //Wife checks shopping bag content.
        //Do not modify these lines!
        Console.WriteLine(shoppingBag.Count(s => s == "Bread")); //Expected 1
        Console.WriteLine(shoppingBag.Count(s => s == "Egg")); //Expected 12
    }
}
