using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Static": TestStatic(); return;
            case "Constant": TestConstant(); return;
            case "Inheritance": TestInheritance(); return;
            case "Encapsulation": TestAccessModifiers(); return;
            case "Functionality": TestFunctionality(); return;
            default: throw new ArgumentException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestStatic() {
        string method = "OfferAssistance";
        MethodInfo methodInfo = typeof(Computer).GetMethod(method,
            BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.Public | BindingFlags.NonPublic);
        if (methodInfo is null) {
            Console.WriteLine($"Method not found: {method}");
            return;
        }
        Console.WriteLine($"{method} is a static method: {methodInfo.IsStatic}");
    }

    public static void TestConstant() {
        string field = "_minimumStock";
        FieldInfo fieldInfo = typeof(Electronics).GetField(field,
            BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.Public | BindingFlags.NonPublic);
        if (fieldInfo is null) {
            Console.WriteLine($"Field not found: {field}");
            return;
        }
        Console.WriteLine($"{field} is a constant field: {fieldInfo.IsLiteral}");
    }

    public static void TestInheritance() {
        Type baseType = typeof(object);
        Type derivedType = typeof(Product);
        string methodName = "ToString";
        MethodInfo baseMethod = baseType.GetMethod(methodName, []);
        MethodInfo derivedMethod = derivedType.GetMethod(methodName, []);
        Console.WriteLine($"In Product, method {methodName} is overridden: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        // Inheritance Product to Clothes
        baseType = typeof(Product);
        derivedType = typeof(Clothes);
        Console.WriteLine("\nClothes is derived from Product: "
            + derivedType.IsSubclassOf(baseType));
        methodName = "Sell";
        Type[] parameterTypes = new Type[] { typeof(int) };
        baseMethod = baseType.GetMethod(methodName, parameterTypes);
        derivedMethod = derivedType.GetMethod(methodName, parameterTypes);
        Console.WriteLine($" - Method {methodName} is overridden in Product: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));
        methodName = "ToString";
        baseMethod = baseType.GetMethod(methodName, new Type[] { });
        derivedMethod = derivedType.GetMethod(methodName, new Type[] { });
        Console.WriteLine($" - Method {methodName} is overridden in Product: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        // Inheritance Product to Electronics
        baseType = typeof(Product);
        derivedType = typeof(Electronics);
        Console.WriteLine("\nElectronics is derived from Product: "
            + derivedType.IsSubclassOf(baseType));
        methodName = "Sell";
        parameterTypes = new Type[] { typeof(int) };
        baseMethod = baseType.GetMethod(methodName, parameterTypes);
        derivedMethod = derivedType.GetMethod(methodName, parameterTypes);
        Console.WriteLine($" - Method {methodName} is overridden in Electronics: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));
        methodName = "ToString";
        baseMethod = baseType.GetMethod(methodName, new Type[] { });
        derivedMethod = derivedType.GetMethod(methodName, new Type[] { });
        Console.WriteLine($" - Method {methodName} is overridden in Electronics: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        // Inheritance Electronics to Computer
        baseType = typeof(Electronics);
        derivedType = typeof(Computer);
        Console.WriteLine("\nComputer is derived from Electronics: "
            + derivedType.IsSubclassOf(baseType));
        methodName = "Sell";
        parameterTypes = new Type[] { typeof(int) };
        baseMethod = baseType.GetMethod(methodName, parameterTypes);
        derivedMethod = derivedType.GetMethod(methodName, parameterTypes);
        Console.WriteLine($" - Method {methodName} is overridden in Computer: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));
        methodName = "ToString";
        baseMethod = baseType.GetMethod(methodName, new Type[] { });
        derivedMethod = derivedType.GetMethod(methodName, new Type[] { });
        Console.WriteLine($" - Method {methodName} is overridden in Electronics: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        Console.WriteLine("\nTesting making objects...");
        List<Product> products = new() {
            new Product("", 0, 0),
            new Clothes("", 0, 0, "", ""),
            new Electronics("", 0, 0, "", ""),
            new Computer("", 0, 0, "", ""),
        };
        Console.WriteLine("Done!");
    }

    public static void TestAccessModifiers() {
        // Clothes
        string className = "Clothes";
        Console.WriteLine($"Class {className}");
        string methodName = "WashingInstructions";
        Console.WriteLine($" - Method {methodName} encapsulation: "
            + TestAccessModifierMethod(className, methodName, "Private"));

        // Electronics
        className = "Electronics";
        Console.WriteLine($"\nClass {className}");
        string fieldName = "_minimumStock";
        Console.WriteLine($" - Field {fieldName} encapsulation: "
            + TestAccessModifierField(className, fieldName, "Private"));
        methodName = "Restock";
        Console.WriteLine($" - Method {methodName} encapsulation: "
            + TestAccessModifierMethod(className, methodName, "Private"));

        // Computer
        className = "Computer";
        Console.WriteLine($"\nClass {className}");
        methodName = "OfferAssistance";
        Console.WriteLine($" - Method {methodName} encapsulation: "
            + TestAccessModifierMethod(className, methodName, "Private"));
    }

    public static void TestFunctionality() {
        List<Product> products = [
            new Product("Mug", 3, 15),
            new Clothes("Shirt", 25, 20, "L", "Cotton"),
            new Clothes("Sweater", 20, 20, "S", "Wool"),
            new Clothes("Dress", 35, 15, "M", "Linen"),
            new Clothes("Leather Jacket", 35, 10, "XL", "Leather"),
            new Electronics("Screen", 200, 10, "Samsung", "LS27BM500EU"),
            new Computer("Laptop", 800, 10, "Dell", "Inspiron"),
        ];

        Console.WriteLine("Mugs");
        products[0].Sell(10);
        products[0].Sell(10);

        Console.WriteLine("\nShirts");
        products[1].Sell(20);
        products[1].Sell(1);

        Console.WriteLine("\nSweater");
        products[2].Sell(1);
        Console.WriteLine("\nDress");
        products[3].Sell(1);
        Console.WriteLine("\nJacket");
        products[4].Sell(1);

        Console.WriteLine("\nScreens");
        products[5].Sell(10);
        products[5].Sell(10);
        products[5].Sell(11);

        Console.WriteLine("\nLaptops");
        products[6].Sell(10);
        products[6].Sell(5);
        products[6].Sell(3);
        products[6].Sell(6);

        Console.WriteLine("\nTest each class' ToString()");
        foreach (var product in products) {
            Console.WriteLine(product);
        }
    }

    private static string TestAccessModifierField(string cls, string field, string modifier) {
        var targetType = Type.GetType(cls);
        var fieldInfo = targetType?.GetField(field,
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static);

        if (fieldInfo == null)
            return $"Field not found: {field}";

        bool flag;
        switch (modifier) {
            case "Public":
                flag = fieldInfo.IsPublic;
                break;
            case "Private":
                flag = fieldInfo.IsPrivate;
                break;
            default:
                flag = false;
                break;
        }

        return flag ? "Correct!" : "Incorrect.";
    }

    private static string TestAccessModifierMethod(string cls, string method, string modifier) {
        var targetType = Type.GetType(cls);
        var methodInfo = targetType?.GetMethod(method,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (methodInfo == null)
            return $"Method not found: {method}";

        bool flag;
        switch (modifier) {
            case "Public":
                flag = methodInfo.IsPublic;
                break;
            case "Family":
                flag = methodInfo.IsFamily;
                break;
            case "Private":
                flag = methodInfo.IsPrivate;
                break;
            default:
                flag = false;
                break;
        }

        return flag ? "Correct!" : "Incorrect.";
    }
}
