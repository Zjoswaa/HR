using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "ReadOnly": TestReadOnly(); return;
            case "Constant": TestConstant(); return;
            case "Overload": TestOverloads(); return;
            case "Inheritance": TestInheritance(); return;
            case "OrderAndURL": TestFieldOrderAndFullURL(); return;
            case "Functionality": TestFunctionality(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        };
    }

    public static void TestReadOnly() {
        Console.WriteLine("=== Webshop ===");
        Type clsType = typeof(WebShop);
        PrintIsFieldReadOnly(clsType, "Domain");
        PrintIsFieldReadOnly(clsType, "FullURL");
        PrintIsFieldReadOnly(clsType, "Path");
        PrintIsFieldReadOnly(clsType, "ItemsForSale");

        Console.WriteLine("\n=== ShoppingCart ===");
        clsType = typeof(ShoppingCart);
        PrintIsFieldReadOnly(clsType, "ItemsToOrder");

        Console.WriteLine("\n=== Item ===");
        clsType = typeof(Item);
        PrintIsFieldReadOnly(clsType, "Name");

        Console.WriteLine("\n=== MagicItem ===");
        clsType = typeof(MagicItem);
        PrintIsFieldReadOnly(clsType, "EffectDescription");

        Console.WriteLine("\n=== GroupedItem ===");
        clsType = typeof(GroupedItem);
        PrintIsFieldReadOnly(clsType, "MyItem");
    }

    public static void TestConstant() {
        Type clsType = typeof(GroupedItem);
        PrintIsFieldConstant(clsType, "MinQuantity");
    }

    public static void TestFieldOrderAndFullURL() {
        string[] fieldNames = ["Domain", "FullURL", "Path"];
        Type type = typeof(WebShop);
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
        var sortedFields = fields.OrderBy(f => f.MetadataToken);

        List<string> sortedFieldNames = [];
        foreach (FieldInfo field in sortedFields) {
            string fieldName = field.Name;
            if (fieldNames.Contains(fieldName))
                sortedFieldNames.Add(field.Name);
        }
        Console.WriteLine(
            $"The fields {fieldNames[0]}, {fieldNames[1]} and {fieldNames[2]} " +
            $"are declared in the correct order: " +
            fieldNames.SequenceEqual(sortedFieldNames));

        Console.WriteLine($"\nFull URL: {WebShop.FullURL}");
    }

    public static void TestOverloads() {
        string itemName = "Elven Crystal Mug";
        WebShop.AddToCart(itemName);
        WebShop.AddToCart(itemName, 1);

        TextWriter originalOutput = Console.Out;
        Console.SetOut(TextWriter.Null); // Disable Console.WriteLine
        WebShop.CheckoutItem(itemName);
        WebShop.CheckoutItem(itemName, 1);
        ShoppingCart.Checkout();
        ShoppingCart.Checkout(new GroupedItem(new Item(itemName, 1), 1));
        Console.SetOut(originalOutput); // Enable Console.WriteLine

        Item item = new(itemName, 10);
        MagicItem magicItem1 = new(item, "You always seem to spill your drink over your important documents. This magic effect has been dubbed 'Spill Skill'.");
        MagicItem magicItem2 = new(itemName, 50, "You always seem to spill your drink over your important documents. This magic effect has been dubbed 'Spill Skill'.");

        Console.WriteLine("If you can read this, you have overloaded correctly!");
    }

    public static void TestInheritance() {
        Type baseType = typeof(Item);
        Type derivedType = typeof(MagicItem);
        Console.WriteLine($"{derivedType} inherits {baseType}: "
            + derivedType.IsSubclassOf(baseType));
    }

    public static void TestFunctionality() {
        Console.WriteLine("Adding items to shopping cart...");
        WebShop.AddToCart(WebShop.ItemsForSale[0].Name);
        WebShop.AddToCart(WebShop.ItemsForSale[1].Name, 2);
        WebShop.AddToCart(WebShop.ItemsForSale[2].Name, -1); // Quantity should become 1
        WebShop.AddToCart("Mundane item");
        WebShop.AddToCart("Mundane item", 2);
        PrintShoppingCartContents();

        Console.WriteLine("Adjusting quantities...");
        ShoppingCart.IncrementItemQuantity(ShoppingCart.ItemsToOrder[0].MyItem.Name);
        for (int i = 0; i < 3; i++) {
            ShoppingCart.DecrementItemQuantity(ShoppingCart.ItemsToOrder[1].MyItem.Name);
        }
        ShoppingCart.SetItemQuantity(ShoppingCart.ItemsToOrder[1].MyItem.Name, 5);
        ShoppingCart.SetItemQuantity("Mundane item", 6);
        PrintShoppingCartContents();

        Console.WriteLine("Removing specific items...");
        ShoppingCart.RemoveItem(WebShop.ItemsForSale[0].Name);
        ShoppingCart.RemoveItem("Mundane item");
        PrintShoppingCartContents();

        Console.WriteLine("Removing all items...");
        ShoppingCart.EmptyCart();
        PrintShoppingCartContents();

        Console.WriteLine("Re-adding items to shopping cart...");
        WebShop.AddToCart(WebShop.ItemsForSale[0].Name);
        WebShop.AddToCart(WebShop.ItemsForSale[1].Name, 2);
        WebShop.AddToCart(WebShop.ItemsForSale[2].Name, 3);

        WebShop.CheckoutItem(WebShop.ItemsForSale[3].Name);
        WebShop.CheckoutItem(WebShop.ItemsForSale[4].Name, 5);

        Console.WriteLine("Checking out shopping cart items...");
        ShoppingCart.Checkout();
        PrintShoppingCartContents();

        WebShop.CheckoutItem("Mundane item");
        ShoppingCart.Checkout(new GroupedItem(new Item("Mundane item", 1), 1));
    }

    private static void PrintShoppingCartContents() {
        Console.WriteLine("Currently in shopping cart:");
        foreach (GroupedItem gi in ShoppingCart.ItemsToOrder) {
            Console.WriteLine($" - {gi.MyItem.Name} x {gi.Quantity}");
        }
        Console.WriteLine();
    }

    private static void PrintIsFieldReadOnly(Type clsType, string fieldName) {
        FieldInfo info = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (info is not null) {
            Console.WriteLine($"{info.Name} is a read-only field: " +
                info.IsInitOnly);
        } else {
            Console.WriteLine($"Field {fieldName} not found in {clsType.Name}");
        }
    }

    private static void PrintIsFieldConstant(Type clsType, string fieldName) {
        FieldInfo info = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (info is not null) {
            Console.WriteLine($"{info.Name} is a constant field: " +
                info.IsLiteral);
        } else {
            Console.WriteLine($"Field {fieldName} not found in {clsType.Name}");
        }
    }
}
