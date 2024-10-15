using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Familiar": TestFamiliar(); return;
            case "Interface": TestInterface(); return;
            case "Spells": TestSpells(); return;
            case "SpellFunct": TestSpellsFunctionality(); return;
            case "Remove": TestMemberRemoval(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestFamiliar() {
        Type familiarType = typeof(Familiar);
        Console.WriteLine($"Familiar is no longer a Fighter: "
            + !(familiarType is Fighter));

        // Class Familiar should only have a default constructor, meaning a
        // constructor without parameters. It may also be left out of the code altogether;
        // In this case .NET will add it in the background.
        ConstructorInfo[] constructors = familiarType.GetConstructors();
        if (constructors.Length != 1) {
            Console.WriteLine($"Familiar should have only one constructor.");
            return;
        }
        ConstructorInfo constructor = constructors[0];
        // Check if the constructor is parameterless
        if (constructor.GetParameters().Length == 0)
            Console.WriteLine("Familiar has a default parameterless constructor.");
        else
            Console.WriteLine("Familiar has a constructor that isn't parameterless.");
    }

    public static void TestInterface() {
        Type interfaceType = typeof(ITransform);
        Console.WriteLine($"{interfaceType.Name}:");
        Console.WriteLine(" - is an Interface: " + interfaceType.IsInterface);

        Type[] classTypes = new[] {
            typeof(GargoyleGoblet),
            typeof(Lycanthrope),
            typeof(Witch),
        };
        foreach (var classType in classTypes) {
            Console.WriteLine($" - is implemented by {classType.Name}: "
                + interfaceType.IsAssignableFrom(classType));
        }

        Console.WriteLine(" - member signatures:");
        Console.WriteLine("   - property IsTransformed has the correct type and the correct get/set accessors: "
            + CheckPropertySignature(interfaceType, "IsTransformed", typeof(bool), true, false));
        Console.WriteLine("   - method Transform has the correct return and parameter types: "
            + CheckMethodSignature(interfaceType, "Transform", typeof(void), new Type[] { }));
        Console.WriteLine("   - method Revert has the correct return and parameter types: "
            + CheckMethodSignature(interfaceType, "Revert", typeof(void), new Type[] { }));
    }

    public static void TestSpells() {
        Type witchType = typeof(Witch);
        Console.WriteLine("Method Enchant has the correct return and parameter types: "
            + CheckMethodSignature(witchType, "Enchant", typeof(void), new Type[] { typeof(List<ITransform>) }));
        Console.WriteLine("Method Disenchant has the correct return and parameter types: "
            + CheckMethodSignature(witchType, "Disenchant", typeof(void), new Type[] { typeof(List<ITransform>) }));
    }

    public static void TestSpellsFunctionality() {
        Witch scotia = new("Scotia", new BlackCat());

        List<ITransform> transformers = new() {
            new Lycanthrope("Kevin"),
            new GargoyleGoblet(),
            new Witch("Elinee", new Familiar()),
        };

        World.SwitchTime(); // Make it night time

        Console.WriteLine($"Witch {scotia.Name}'s current MP: {scotia.CurrentMagicPoints}\n");

        scotia.Enchant(transformers);
        foreach (var transformer in transformers) {
            Console.WriteLine($"Transformed: {transformer.IsTransformed}");
        }

        Console.WriteLine($"\nWitch {scotia.Name}'s current MP: {scotia.CurrentMagicPoints}\n");

        scotia.Disenchant(transformers);
        foreach (var transformer in transformers) {
            Console.WriteLine($"Transformed: {transformer.IsTransformed}");
        }

        Console.WriteLine($"\nWitch {scotia.Name}'s current MP: {scotia.CurrentMagicPoints}");
    }

    public static void TestMemberRemoval() {
        Type fighterType = typeof(Fighter);
        PropertyInfo property = fighterType.GetProperty("CanTransform");
        Console.WriteLine($"Property CanTransform was removed: "
            + (property is null));
        property = fighterType.GetProperty("IsTransformed");
        Console.WriteLine($"Property IsTransformed was removed: "
            + (property is null));
        MethodInfo method = fighterType.GetMethod("Transform");
        Console.WriteLine($"Method Transform was removed: "
            + (method is null));
        method = fighterType.GetMethod("Revert");
        Console.WriteLine($"Method Revert was removed: "
            + (method is null));
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
