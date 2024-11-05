using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Interface": TestInterface(); return;
            case "Abstract": TestAbstract(); return;
            case "Encapsulation": TestEncapsulation(); return;
            case "FunctBook": TestFuncBook(); return;
            case "FunctEReader": TestFuncEReader(); return;
            case "FunctLibrary": TestFuncLibrary(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestInterface() {
        Type interfaceType = typeof(IBorrow);
        Type implementingType = typeof(Publication);

        Console.WriteLine("Is an Interface: " + interfaceType.IsInterface);
        Console.WriteLine($"Is implemented by {implementingType}: "
            + interfaceType.IsAssignableFrom(implementingType));

        // Check whether the members have the correct signatures
        string propertyName = "Status";
        Console.WriteLine($"Property {propertyName} has the correct type and the correct get/set accessors: "
            + CheckPropertySignature(interfaceType, propertyName, typeof(string), true, false));
        string methodName = "UpdateStatus";
        Console.WriteLine($"Method {methodName} has the correct return and parameter types: "
            + CheckMethodSignature(interfaceType, methodName, typeof(void), []));
        methodName = "Borrow";
        Console.WriteLine($"Method {methodName} has the correct return and parameter types: "
            + CheckMethodSignature(interfaceType, methodName, typeof(void), []));
    }

    public static void TestAbstract() {
        Type baseClass = typeof(Publication);

        Console.WriteLine("=== Testing abstraction ===");
        Console.WriteLine($"{baseClass} cannot be instantiated: "
            + (baseClass.IsAbstract && !baseClass.IsInterface));

        string methodName = "UpdateStatus";
        Console.WriteLine($"Method {methodName} has no implementation: "
            + baseClass.GetMethod(methodName).IsAbstract);
        methodName = "Borrow";
        Console.WriteLine($"Method {methodName} has no implementation: "
            + baseClass.GetMethod(methodName).IsAbstract);

        Console.WriteLine("\n=== Testing inheritance ===");
        Type derivedClass = typeof(Book);
        bool isDerivedFromBase = derivedClass.IsSubclassOf(baseClass);
        Console.WriteLine($"Is {derivedClass} derived from {baseClass}? {isDerivedFromBase}");

        Console.WriteLine("\n=== Testing properties ===");
        List<Publication> publications = [
            new Book("Fyodor Dostoevsky", "Crime and Punishment", 5),
            new Book("George Orwell", "1984", 10),
        ];
        foreach (Publication publication in publications) {
            Console.WriteLine($"Title: {publication.Title}");
            Console.WriteLine($"Status: {publication.Status}");
            Console.WriteLine();
        }
    }

    public static void TestEncapsulation() {
        // Publication
        string className = "Publication";
        Console.WriteLine($"Class {className}");

        string propertyName = "Title";
        Console.WriteLine($" - Property {propertyName} encapsulation: "
            + TestAccessModifierProperty(className, propertyName, "Public", null));

        propertyName = "Status";
        Console.WriteLine($" - Property {propertyName} encapsulation: "
            + TestAccessModifierProperty(className, propertyName, "Public", "Family"));

        // Book
        className = "Book";
        Console.WriteLine($"\nClass {className}");

        propertyName = "Author";
        Console.WriteLine($" - Property {propertyName} encapsulation: "
            + TestAccessModifierProperty(className, propertyName, "Public", null));

        propertyName = "AmountAvailable";
        Console.WriteLine($" - Property {propertyName} encapsulation: "
            + TestAccessModifierProperty(className, propertyName, "Public", "Private"));

        // EReader
        className = "EReader";
        Console.WriteLine($"\nClass {className}");

        propertyName = "Status";
        Console.WriteLine($" - Property {propertyName} encapsulation: "
            + TestAccessModifierProperty(className, propertyName, "Public", "Private"));

        propertyName = "IsAvailable";
        Console.WriteLine($" - Property {propertyName} encapsulation: "
            + TestAccessModifierProperty(className, propertyName, "Public", "Private"));
    }

    public static void TestFuncBook() {
        List<Book> books = [
            new Book("Fyodor Dostoevsky", "Crime and Punishment", 5),
            new Book("George Orwell", "1984", 10),
        ];

        foreach (Book book in books) {
            Console.WriteLine($"{book.Title} by {book.Author}");
            Console.WriteLine($"Status: {book.Status}");
            Console.WriteLine();
        }

        Console.WriteLine("Attempt to borrow 6 copies...");
        foreach (Book book in books) {
            for (int i = 0; i < 6; i++) {
                book.Borrow();
            }
        }

        Console.WriteLine("\nChecking the statuses of the books:");
        foreach (Book book in books) {
            Console.WriteLine($"{book.Title} by {book.Author}");
            Console.WriteLine($"Status: {book.Status}");
            Console.WriteLine();
        }
    }

    public static void TestFuncEReader() {
        EReader ereader = new();

        Console.WriteLine("Borrowing EReader...");
        ereader.Borrow();
        Console.WriteLine("Checking the status of the EReader:");
        Console.WriteLine($"Status: {ereader.Status}");

        Console.WriteLine("\nAttempting to borrow EReader again...");
        ereader.Borrow();
        Console.WriteLine("Checking the status of the EReader:");
        Console.WriteLine($"Status: {ereader.Status}");
    }

    public static void TestFuncLibrary() {
        List<IBorrow> borrowables = [
            new Book("Fyodor Dostoevsky", "Crime and Punishment", 5),
            new Book("George Orwell", "1984", 10),
            new EReader(),
        ];

        Library.Checkout(borrowables);
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

    private static bool CheckMethodSignature(Type interfaceType, string methodName, Type expectedReturnType, params Type[] expectedParameterTypes) {
        var method = interfaceType.GetMethod(methodName);

        if (method == null) {
            Console.WriteLine($" - Method {methodName} not found in the interface.");
            return false;
        }

        if (method.ReturnType != expectedReturnType) {
            Console.WriteLine($" - Incorrect return type for method {methodName}. Expected: {expectedReturnType}, Actual: {method.ReturnType}");
            return false;
        }

        var parameters = method.GetParameters();
        if (parameters.Length != expectedParameterTypes.Length) {
            Console.WriteLine($" - Incorrect number of parameters for method {methodName}. Expected: {expectedParameterTypes.Length}, Actual: {parameters.Length}");
            return false;
        }

        for (int i = 0; i < expectedParameterTypes.Length; i++) {
            if (parameters[i].ParameterType != expectedParameterTypes[i]) {
                Console.WriteLine($" - Incorrect parameter type for parameter {parameters[i].Name} in method {methodName}. Expected: {expectedParameterTypes[i]}, Actual: {parameters[i].ParameterType}");
                return false;
            }
        }

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
