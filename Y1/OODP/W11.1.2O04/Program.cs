using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Abstract":
                TestAbstract();
                return;
            case "Inheritance":
                TestInheritance();
                return;
            case "ISelectable":
                TestISelectable();
                return;
            case "Implement":
                TestImplementation();
                return;
            case "TowerWhere":
                TestTowerWhereClause();
                return;
            case "BuildWhere":
                TestBuildWhereClause();
                return;
            case "Circle":
                TestCircle();
                return;
            case "Square":
                TestSquare();
                return;
            case "Tower":
                TestTower();
                return;
            case "Builder":
                TestTowerBuilder();
                return;
            default: throw new ArgumentException();
        }
    }

    public static void TestAbstract() {
        Type shapeType = Type.GetType("Shape");
        Console.WriteLine("Shape is abstract: "
                          + (shapeType.IsAbstract && !shapeType.IsInterface));
    }

    public static void TestInheritance() {
        string baseclassName = "Shape";
        Console.WriteLine($"Circle inherits from {baseclassName}: "
                          + Type.GetType(baseclassName).IsAssignableFrom(Type.GetType("Circle")));
        Console.WriteLine($"Square inherits from {baseclassName}: "
                          + Type.GetType(baseclassName).IsAssignableFrom(Type.GetType("Square")));
    }

    public static void TestISelectable() {
        Type interfaceType = Type.GetType("ISelectable");
        Console.WriteLine($"{interfaceType} has void method Select with no parameters: " +
                          HasMethodSignature(interfaceType, "Select", typeof(void), new Type[0]));
        Console.WriteLine($"{interfaceType} has void method Deselect with no parameters: " +
                          HasMethodSignature(interfaceType, "Deselect", typeof(void), new Type[0]));
        Console.WriteLine($"{interfaceType} has readable bool property IsSelected: " +
                          HasProperty(interfaceType, "IsSelected", typeof(bool), true));
    }

    public static void TestImplementation() {
        string interfaceName = "ISelectable";
        Console.WriteLine($"Circle has implemented {interfaceName}: "
                          + Type.GetType(interfaceName).IsAssignableFrom(Type.GetType("Circle")));
        Console.WriteLine($"Square has implemented {interfaceName}: "
                          + Type.GetType(interfaceName).IsAssignableFrom(Type.GetType("Square")));

        interfaceName = "IStackable";
        Console.WriteLine($"Circle has NOT implemented {interfaceName}: "
                          + !Type.GetType(interfaceName).IsAssignableFrom(Type.GetType("Circle")));
        Console.WriteLine($"Square has implemented {interfaceName}: "
                          + Type.GetType(interfaceName).IsAssignableFrom(Type.GetType("Square")));
    }

    public static void TestTowerWhereClause() {
        Type constraintType = typeof(IStackable);
        Type[] genericConstraints = typeof(Tower<>).GetGenericArguments()[0].GetGenericParameterConstraints();
        Console.WriteLine($"Tower is constraint to type {constraintType.Name}: "
                          + genericConstraints.Contains(constraintType));
    }

    public static void TestBuildWhereClause() {
        Type builderType = typeof(TowerBuilder);
        string methodName = "Build";
        MethodInfo methodInfo = builderType.GetMethod(methodName);
        Type[] genericConstraints = methodInfo.GetGenericArguments()[0].GetGenericParameterConstraints();

        Console.WriteLine($"Method {methodName} is constraint to ISelectable and IStackable: "
                          + (genericConstraints.Contains(typeof(IStackable))
                             && genericConstraints.Contains(typeof(ISelectable))));
    }

    public static void TestCircle() {
        Console.WriteLine("Creating a circle...");
        Circle circle = new(5.5);
        Console.WriteLine("Is the circle selected? " + circle.IsSelected);
        Console.WriteLine("Selecting the circle...");
        circle.Select();
        Console.WriteLine("Is the circle selected? " + circle.IsSelected);
        Console.WriteLine("Deselecting the circle...");
        circle.Deselect();
        Console.WriteLine("Is the circle selected? " + circle.IsSelected);
        Console.WriteLine("Deselecting the circle...");
        circle.Deselect();
        Console.WriteLine("Is the circle selected? " + circle.IsSelected);
    }

    public static void TestSquare() {
        Console.WriteLine("Creating a square...");
        Square square = new(2.5);
        Console.WriteLine("Is the square selected? " + square.IsSelected);
        Console.WriteLine("Selecting the square...");
        square.Select();
        Console.WriteLine("Is the square selected? " + square.IsSelected);
        Console.WriteLine("Deselecting the square...");
        square.Deselect();
        Console.WriteLine("Is the square selected? " + square.IsSelected);
        Console.WriteLine("Deselecting the square...");
        square.Deselect();
        Console.WriteLine("Is the square selected? " + square.IsSelected);
    }

    public static void TestTower() {
        Tower<Square> tower1 = new(3);
        tower1.Add(new Square(2.5));
        
        Tower<Square> tower2 = new(tower1);
        tower2.Add(new Square(5));
        
        Tower<Square> tower3 = tower1 + new Square(10);
        tower3.Add(new Square(20));
        tower3.Add(new Square(40));

        foreach (var tower in new List<Tower<Square>>() { tower1, tower2, tower3 }) {
            Console.WriteLine("Shape count in this tower: " + tower.Index);
        }
    }

    public static void TestTowerBuilder() {
        Tower<Square> tower = new(3);
        Square square1 = new(2);
        Square square2 = new(4);
        TowerBuilder.Build(tower, square1);
        TowerBuilder.Build(tower, square2);

        Console.WriteLine("Shape count in this tower: " + tower.Index);
    }

    private static bool HasMethodSignature(Type interfaceType, string methodName, Type returnType,
        Type[] parameterTypes) {
        MethodInfo[] methods = interfaceType.GetMethods();

        foreach (MethodInfo methodInfo in methods) {
            if (methodInfo.Name == methodName) {
                ParameterInfo[] parameters = methodInfo.GetParameters();

                if (methodInfo.ReturnType == returnType &&
                    parameters.Select(p => p.ParameterType).SequenceEqual(parameterTypes)) {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool HasProperty(Type interfaceType, string propertyName, Type propertyType, bool isReadOnly) {
        PropertyInfo[] properties = interfaceType.GetProperties();

        foreach (PropertyInfo propertyInfo in properties) {
            if (propertyInfo.Name == propertyName) {
                if (propertyInfo.PropertyType == propertyType &&
                    (!isReadOnly || (propertyInfo.CanRead && !propertyInfo.CanWrite))) {
                    return true;
                }
            }
        }

        return false;
    }
}
