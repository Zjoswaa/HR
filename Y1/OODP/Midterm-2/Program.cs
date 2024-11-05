using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Inheritance": TestInheritance(); return;
            case "Polymorphism": TestPolymorphism(); return;
            case "Encapsulation": TestEncapsulation(); return;
            case "FunctBoardgameToString": TestBoardgameToString(); return;
            case "FunctBoardgameExpansion": TestBoardgameExpansion(); return;
            case "FunctBoardgameDiscount": TestBoardgameDiscount(); return;
            case "FunctShop": TestShop(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestInheritance() {
        // Inheritance Product to Boardgame
        Type baseType = typeof(Product);
        Type derivedType = typeof(Boardgame);
        Console.WriteLine($"{derivedType} is derived from {baseType}: "
            + derivedType.IsSubclassOf(baseType));

        // Method ApplyDiscount
        string methodName = "ApplyDiscount";
        MethodInfo? baseMethod = baseType.GetMethod(methodName, Type.EmptyTypes);
        MethodInfo? derivedMethod = derivedType.GetMethod(methodName, Type.EmptyTypes);
        Console.WriteLine($" - Method {methodName} is overridden in {derivedType}: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        // Method ToString
        baseType = typeof(object);
        methodName = "ToString";
        baseMethod = baseType.GetMethod(methodName);
        derivedMethod = derivedType.GetMethod(methodName);
        Console.WriteLine($" - Method {methodName} is overridden in {derivedType}: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        // Inheritance Product to BoardgameExpansion
        baseType = typeof(Product);
        derivedType = typeof(BoardgameExpansion);
        Console.WriteLine($"{derivedType} is derived from {baseType}: "
            + derivedType.IsSubclassOf(baseType));

        // Property Name
        string propertyName = "Name";
        PropertyInfo baseProperty = baseType.GetProperty(propertyName);
        PropertyInfo derivedProperty = derivedType.GetProperty(propertyName);
        Console.WriteLine($" - Property {propertyName} is overridden in {derivedType}: " +
            (!ReferenceEquals(baseProperty, derivedProperty)));
    }

    public static void TestPolymorphism() {
        Console.WriteLine("=== Testing overload of Product's constructor ===");
        Product product1 = new("Coffee beans", 15);
        Product product2 = new("Coffee beans sample");
        Console.WriteLine($"product1 Price: {product1.Price}"); // 15
        Console.WriteLine($"product2 Price: {product2.Price}"); // 0

        Console.WriteLine("\n=== Testing overload of method ApplyDiscount ===");
        Product product3 = new("Coffee beans", 15);
        product1.ApplyDiscount();
        product3.ApplyDiscount(0.3);
        Console.WriteLine($"product1 Price: {product1.Price}"); // 13
        Console.WriteLine($"product3 Price: {product3.Price}"); // 10
        product1.ApplyDiscount();
        product3.ApplyDiscount(0.3);
        Console.WriteLine($"product1 Price: {product1.Price}"); // 11
        Console.WriteLine($"product3 Price: {product3.Price}"); // 7

        Boardgame boardgame1 = new("Starship Samurai", 60, 4);
        Boardgame boardgame2 = new("Architects of the West Kingdom", 40, 4);
        boardgame1.ApplyDiscount();
        boardgame2.ApplyDiscount(0.4);
        Console.WriteLine($"boardgame1 Price: {boardgame1.Price}"); // 54
        Console.WriteLine($"boardgame2 Price: {boardgame2.Price}"); // 24
    }

    public static void TestEncapsulation() {
        // Product
        string className = "Product";
        Console.WriteLine($"{className} members encapsulation:");
        Console.WriteLine(
            " - Property Name: " +
            TestAccessModifierProperty(className, "Name", "Public", null));
        Console.WriteLine(
            " - Property Price: " +
            TestAccessModifierProperty(className, "Price", "Public", "Family"));

        // Boardgame
        className = "Boardgame";
        Console.WriteLine($"\n{className} members encapsulation:");
        Console.WriteLine(
            " - Property Expansion: " +
            TestAccessModifierProperty(className, "Expansion", "Public", "Public"));
        Console.WriteLine(
            " - Property NumberOfPlayers: " +
            TestAccessModifierProperty(className, "NumberOfPlayers", "Public", null));
    }

    public static void TestBoardgameToString() {
        Boardgame boardgame1 = new("Dune Imperium", 60, 4);
        Console.WriteLine(boardgame1);

        Console.WriteLine();

        Boardgame boardgame2 = new("Lost Ruins of Arnak", 50, 4);
        Console.WriteLine(boardgame2);
    }

    public static void TestBoardgameExpansion() {
        Boardgame boardgame = new("Dune Imperium", 60, 4);
        Console.WriteLine($"Dune Imperium number of players: {boardgame.NumberOfPlayers}");
        Console.WriteLine($"Dune Imperium Expansion: {(boardgame.Expansion is null ? "-" : boardgame.Expansion.Name)}");

        boardgame.Expansion = new BoardgameExpansion("Rise of Ix", 30);
        Console.WriteLine($"\nDune Imperium number of players: {boardgame.NumberOfPlayers}");
        Console.WriteLine($"Dune Imperium Expansion: {(boardgame.Expansion is null ? "-" : boardgame.Expansion.Name)}");

        boardgame.Expansion = null; // null should not be set
        Console.WriteLine($"\nDune Imperium number of players: {boardgame.NumberOfPlayers}");
        Console.WriteLine($"Dune Imperium Expansion: {(boardgame.Expansion is null ? "-" : boardgame.Expansion.Name)}");

        boardgame.Expansion = new BoardgameExpansion("Uprising", 30);
        Console.WriteLine($"\nDune Imperium number of players: {boardgame.NumberOfPlayers}");
        Console.WriteLine($"Dune Imperium Expansion: {(boardgame.Expansion is null ? "-" : boardgame.Expansion.Name)}");
    }

    public static void TestBoardgameDiscount() {
        Boardgame boardgame = new("Dune Imperium", 60, 4);
        Console.WriteLine($"Boardgame price before discount: {boardgame.Price}");

        boardgame.ApplyDiscount();
        Console.WriteLine($"Board game price after discount (without expansion): {boardgame.Price}");

        boardgame = new("Dune Imperium", 60, 4);
        boardgame.Expansion = new BoardgameExpansion("Rise of Ix", 30);
        boardgame.ApplyDiscount();
        Console.WriteLine($"Boardgame price after discount (with expansion): {boardgame.Price}");
    }

    public static void TestShop() {
        List<Product> products =
        [
            new Product("Chess", 20),
            new Product("Tea", 3),
            new Product("Cheese", 10),
            new Boardgame("Machi Koro", 30, 4),
            new BoardgameExpansion("Harbor", 25),
            new BoardgameExpansion("Hidden Signs", 17),
            new Boardgame("Chess", 20, 2),
            new Product("White Cholocate", 12),
            new Product("Milk Cholocate", 12),
            new Product("Dark Cholocate", 12),
            new Product("Checkers", 15),
            new Product("Pens", 1),
            new Product("Pencils", 1),
            new Product("Papers", 2),
            new Boardgame("Checkers", 15, 2),
            new Product("Glue", 1),
            new Product("Greeting Card", 1),
            new Boardgame("Battleship", 23, 4),
            new Boardgame("Ludo", 16, 4),
            new Boardgame("Monopoly", 35, 8),
            new Boardgame("Settlers of Catan", 38, 4),
            new BoardgameExpansion("Seafarers", 32),
            new BoardgameExpansion("Cities & Knights", 40),
            new BoardgameExpansion("Traders & Barbarians", 42),
            new BoardgameExpansion("Explorers & Pirates", 45),
            new Product("Battleship", 23),
        ];

        foreach (var product in products) {
            Shop.AddProduct(product);
        }

        Console.WriteLine("Products:");
        foreach (var p in Shop.Products) {
            Console.WriteLine($" - {p.Name} (Price: {p.Price})");
        }
        Console.WriteLine("\nBoard games:");
        foreach (var bg in Shop.Boardgames) {
            Console.WriteLine($" - {bg.Name} (Price: {bg.Price})");
            if (bg.Expansion != null)
                Console.WriteLine($"   - Expansion: {bg.Expansion.Name}");
        }
        Console.WriteLine("\nExpansions:");
        foreach (var exp in Shop.Expansions) {
            Console.WriteLine($" - {exp.Name} (Price: {exp.Price})");
        }
    }

    private static string TestAccessModifierProperty(string cls, string property, string getTest, string setTest) {
        var p = Type.GetType(cls).GetProperty(property,
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance);
        if (p == null)
            return $"Property not found: {property}";

        if (getTest == null && p.CanRead ||
            getTest != null && !p.CanRead ||
            setTest == null && p.CanWrite ||
            setTest != null && !p.CanWrite)
            return "Incorrect";

        if (p.CanRead) {
            bool readFlag = getTest switch {
                "Public" => p.GetMethod.IsPublic,
                "Family" => p.GetMethod.IsFamily,
                "Private" => p.GetMethod.IsPrivate,
                _ => false
            };
            if (readFlag == false)
                return "Incorrect";
        }

        if (p.CanWrite) {
            bool writeFlag = setTest switch {
                "Public" => p.SetMethod.IsPublic,
                "Family" => p.SetMethod.IsFamily,
                "Private" => p.SetMethod.IsPrivate,
                _ => false
            };
            if (writeFlag == false)
                return "Incorrect";
        }

        return "Correct!";
    }
}
