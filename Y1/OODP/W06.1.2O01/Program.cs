using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Interface": TestInterface(); return;
            case "Encapsulation": TestEncapsulation(); return;
            case "Hint": TestHint(); return;
            case "MinMax": TestFixMinMaxAges(); return;
            case "ToString": TestToString(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestInterface() {
        Type interfaceType = typeof(IAgeSuitability);
        Type toyType = typeof(Toy);
        Type movieType = typeof(Movie);

        Console.WriteLine("Is an Interface: " + interfaceType.IsInterface);
        Console.WriteLine("\nIs implemented by Toy: "
            + interfaceType.IsAssignableFrom(toyType));
        Console.WriteLine("Is implemented by Movie: "
            + interfaceType.IsAssignableFrom(movieType));

        Console.WriteLine("\nProperty AgeSuitability has the correct type and the correct get/set accessors: "
            + CheckPropertySignature(interfaceType, "AgeSuitability", typeof(string), true, false));
    }

    public static void TestEncapsulation() {
        // Present
        string className = "Present";
        string propertyName = "Hint";
        Console.WriteLine($"{propertyName} members encapsulation:");
        Console.WriteLine($" - Property {propertyName} encapsulation: " +
            TestAccessModifierProperty(className, propertyName, "Public", null));

        // Toy
        className = "Toy";
        propertyName = "AgeSuitability";
        Console.WriteLine($"{className} members encapsulation:");
        Console.WriteLine($" - Property {propertyName} encapsulation: " +
            TestAccessModifierProperty(className, propertyName, "Public", null));

        // Movie
        className = "Movie";
        Console.WriteLine($"{className} members encapsulation:");
        Console.WriteLine($" - Property {propertyName} encapsulation: " +
            TestAccessModifierProperty(className, propertyName, "Public", null));
    }

    public static void TestHint() {
        List<object> boughtObjects = new() {
            new Toy("Sportscar", 5, 8),
            new Toy("Doll", 4, 7),
            new Lego("Excavator", 8),
            new Lego("Harry Potter Castle Hogwarts", 18),
            new BoardGame("Pickomino", "Rio Grande Games", 4, 6),
            new BoardGame("Dune Imperium", "Dire Wolf", 13, 99),
            new Movie("The Batman", 13, 99)
        };

        List<Present> wrappedPresents = new();
        foreach (object obj in boughtObjects) {
            wrappedPresents.Add(new Present(obj));
        }
        wrappedPresents.Add(new Present("Socks"));

        Console.WriteLine("Hints:");
        List<object> unwrappedPresents = new();
        foreach (var present in wrappedPresents) {
            Console.WriteLine(present.Hint);
            present.Unwrap();
            unwrappedPresents.Add(present.GetContents());
        }

        Console.WriteLine($"\nHint for already unwrapped present: " +
            $"{wrappedPresents[0].Hint}");

        Console.WriteLine("\nUnwrapped presents:");
        foreach (object present in unwrappedPresents) {
            Console.Write(" - ");
            if (present is Toy toy)
                Console.WriteLine(toy.Name);
            else if (present is Movie movie)
                Console.WriteLine(movie.Title);
            else if (present is string)
                Console.WriteLine(present);
        }
    }

    public static void TestFixMinMaxAges() {
        Toy testToy = new("Sportscar", 8, 5);
        Lego testLego = new("Excavator", 8);
        BoardGame testBoardGame = new("Pickomino", "Rio Grande Games", 6, 4);
        Movie testMovie = new("The Batman", 99, 13);
        Console.WriteLine("Age suitability toy: " + testToy.AgeSuitability);
        Console.WriteLine("Age suitability Lego: " + testLego.AgeSuitability);
        Console.WriteLine("Age suitability board game: " + testBoardGame.AgeSuitability);
        Console.WriteLine("Age suitability movie: " + testMovie.AgeSuitability);
    }

    public static void TestToString() {
        List<object> boughtObjects = new() {
            new Toy("Sportscar", 5, 8),
            new Toy("Doll", 4, 7),
            new Lego("Excavator", 8),
            new Lego("Harry Potter Castle Hogwarts", 18),
            new BoardGame("Pickomino", "Rio Grande Games", 4, 6),
            new BoardGame("Dune Imperium", "Dire Wolf", 13, 99),
            new Movie("The Batman", 13, 99)
        };

        Console.WriteLine("Bought objects:");
        foreach (object present in boughtObjects) {
            Console.WriteLine(" - " + present);
        }
    }

    private static bool CheckPropertySignature(Type interfaceType, string propertyName, Type expectedPropertyType,
        bool canRead, bool canWrite) {
        var property = interfaceType.GetProperty(propertyName);

        if (property == null) {
            Console.WriteLine($" - Property {propertyName} not found in the interface.");
            return false;
        }

        if (property.PropertyType != expectedPropertyType) {
            Console.WriteLine($" - Incorrect property type for {propertyName}. Expected: {expectedPropertyType}, Actual: {property.PropertyType}");
            return false;
        }

        if (canRead != property.CanRead)
            return false;
        if (canWrite != property.CanWrite)
            return false;

        return true;
    }

    private static string TestAccessModifierProperty(string cls, string property, string getTest, string setTest) {
        var p = Type.GetType(cls).GetProperty(property,
          BindingFlags.NonPublic |
          BindingFlags.Public |
          BindingFlags.Instance);
        if (p == null)
            return $"Property not found: {property}";

        var flag = false;
        if (getTest != null) {
            flag = p.CanRead;
            if (getTest == "Public")
                flag = p.GetMethod.IsPublic;
            else if (getTest == "Family")
                flag = p.GetMethod.IsFamily;
            else if (getTest == "Private")
                flag = p.GetMethod.IsPrivate;
            else
                flag = false;
        }
        if (setTest != null) {
            flag = flag && p.CanWrite;
            if (setTest == "Public")
                flag = flag && p.SetMethod.IsPublic;
            else if (setTest == "Family")
                flag = flag && p.SetMethod.IsFamily;
            else if (setTest == "Private")
                flag = flag && p.SetMethod.IsPrivate;
            else
                flag = false;
        }
        return flag == true ? "Correct!" : "Incorrect.";
    }
}
