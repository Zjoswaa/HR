using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Inheritance": TestInheritance(); return;
            case "Encapsulation": TestEncapsulation(); return;
            case "Functionality": TestFunctionality(); return;
            default: throw new ArgumentException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestInheritance() {
        Console.WriteLine("=== Inheritance of object to Publication ===");
        Type baseType = typeof(object);
        Type derivedType = typeof(Publication);

        // method ToString
        string methodName = "ToString";
        Type[] parameterTypes = { };
        MethodInfo baseMethod = baseType.GetMethod(methodName, parameterTypes);
        MethodInfo derivedMethod = derivedType.GetMethod(methodName, parameterTypes);
        Console.WriteLine($"Method {methodName} is overridden in {derivedType.Name}: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        Console.WriteLine("\n=== Inheritance of Publication to Book ===");
        baseType = typeof(Publication);
        derivedType = typeof(Book);
        Console.WriteLine($"{baseType.Name} is derived from {derivedType.Name}: "
            + derivedType.IsSubclassOf(baseType));

        // method ToString
        baseMethod = baseType.GetMethod(methodName, parameterTypes);
        derivedMethod = derivedType.GetMethod(methodName, parameterTypes);
        Console.WriteLine($"Method {methodName} is overridden in {derivedType.Name}: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        Console.WriteLine("\n=== Inheritance of Publication to Magazine ===");
        derivedType = typeof(Magazine);
        Console.WriteLine($"{baseType.Name} is derived from {derivedType.Name}: "
            + derivedType.IsSubclassOf(baseType));

        // method ToString
        baseMethod = baseType.GetMethod(methodName, parameterTypes);
        derivedMethod = derivedType.GetMethod(methodName, parameterTypes);
        Console.WriteLine($"Method {methodName} is overridden in {derivedType.Name}: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        // property PublishedOn
        string propertyName = "PublishedOn";
        PropertyInfo baseProperty = baseType.GetProperty(propertyName);
        PropertyInfo derivedProperty = derivedType.GetProperty(propertyName);
        Console.WriteLine($"Property {propertyName} is overridden in {baseType.Name}: " +
            (!ReferenceEquals(baseProperty, derivedProperty)));
    }

    public static void TestEncapsulation() {
        // Publication
        string className = "Publication";
        Console.WriteLine($"{className} members encapsulation:");

        string propertyName = "Publisher";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Public", null));
        propertyName = "Title";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Public", null));
        propertyName = "PublicationType";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Public", null));
        propertyName = "Pages";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Public", "Public"));
        propertyName = "Audience";
        Console.WriteLine(
            $" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Family", null));
        propertyName = "PublicationDate";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, null, "Public"));
        propertyName = "IsPublished";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Family", "Family"));

        // Book
        className = "Book";
        Console.WriteLine($"\n{className} members encapsulation:");

        propertyName = "ISBN";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Public", null));
        propertyName = "Author";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Public", null));
        propertyName = "Price";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Public", "Private"));
        propertyName = "Currency";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Public", "Private"));

        // Magazine
        className = "Magazine";
        Console.WriteLine($"\n{className} members encapsulation:");

        propertyName = "Issue";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Private", "Private"));
        propertyName = "PublishedOn";
        Console.WriteLine($" - Property {propertyName}: " +
            TestAccessModifierProperty(className, propertyName, "Public", null));
    }

    public static void TestFunctionality() {
        Console.WriteLine("=== Test #1 ===");

        Publication journal = new(
            "Feasibility Study on the Development of Advanced Humanoid Robots for Military Applications",
            "Skynet Research",
            "Scientific journal",
            5,
            ["Military officials", "Defense contractors", "Academics", "Researchers"]
        );

        Book book = new(
            "978-0060254926",
            "Where the Wild Things Are",
            "Maurice Sendak",
            48,
            "HarperCollins",
            ["Children"],
            25
        ) {
            PublicationDate = new(1963, 11, 13)
        };
        book.SetPriceAndCurrency(25, "EUR");

        Magazine magazine = new(
            "Popular Mechanics",
            "Hearst Communications",
            30,
            ["Engineers", "Technology enthousiasts", "DIY enthousiasts"],
            "January 2021"
        );

        PrintInfo([journal, book, magazine]);

        Console.WriteLine("\n=== Test #2 ===");

        journal = new(
            "A supermassive black hole in a galaxy cluster",
            "Nature",
            "Scientific journal",
            20,
            ["Scientists", "Researchers", "Academics"]) {
            PublicationDate = new(2018, 12, 20)
        };

        journal.Pages = -20;

        book = new(
            "978-0545010221",
            "Harry Potter and the Deathly Hallows",
            "J.K. Rowling",
            607,
            "Bloomsbury",
            ["Children", "Young adults", "Adults"],
            27) {
            PublicationDate = new DateTime(2007, 7, 21)
        };

        book.SetPriceAndCurrency(30.0, "USD");
        book.SetPriceAndCurrency(-4000.0, "JPY");

        magazine = new(
            "IEEE Spectrum",
            "Institute of Electrical and Electronics Engineers (IEEE)",
            40,
            ["Engineers", "Researchers"],
            "December 2020") {
            PublicationDate = new(2020, 3, 20)
        };

        PrintInfo([journal, book, magazine]);
    }

    private static void PrintInfo(List<Publication> publications) {
        List<string> audiences = ["Engineers", "Researchers"];
        foreach (var p in publications) {
            Console.WriteLine(p.PublicationType);
            Console.WriteLine(p.ToString());
            Console.WriteLine(p.PublishedOn);
            foreach (string a in audiences) {
                Console.WriteLine($"Suitable for {a.ToLower()}: "
                    + p.IsSuitableForAudience(a));
            }
            if (p is Book) {
                Console.WriteLine($"Suitable for children: "
                    + (p as Book).IsSuitableForChild());
            }
            Console.WriteLine();
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
