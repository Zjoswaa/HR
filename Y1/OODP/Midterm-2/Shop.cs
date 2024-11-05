static class Shop {
    public readonly static List<Product> Products = [
        new("Coffee beans", 15),
        new("Natural Geographic", 10),
        new("Crime and Punishment", 20),
    ];

    public readonly static List<Boardgame> Boardgames = [
        new("Dune Imperium", 60, 4),
        new("Mysterium", 40, 7),
        new("Wingspan", 50, 5),
        new("Pandemic", 25, 4),
        new("Lost Ruins of Arnak", 50, 4),
    ];

    public readonly static List<BoardgameExpansion> Expansions = [
        new("Immortality", 30),
        new("On the Brink", 40),
        new("European", 30),
        new("The Missing Expedition", 30),
    ];

    static Shop() {
        Boardgames[0].Expansion = Expansions[0];
        Boardgames[2].Expansion = Expansions[2];
        Boardgames[3].Expansion = Expansions[1];
        Boardgames[4].Expansion = Expansions[3];
    }

    public static void AddProduct(Product product) {
        if (product is Boardgame boardGame) {
            Boardgames.Add(boardGame);
        } else if (product is BoardgameExpansion boardGameExpansion) {
            Expansions.Add(boardGameExpansion);
        } else {
            Products.Add(product);
        }
    }
}
