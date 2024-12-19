using System.Reflection;

static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Type": TestType(); return;
            case "Encapsulation": TestEncapsulation(); return;
            case "Equals": TestEquals(); return;
            case "Functionality": TestFunctionality(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestType()
    {
        Type carType = typeof(Car);
        PropertyInfo tireInfo = carType.GetProperty("Tires");

        Console.WriteLine("Tires is either an array, Tuple or ValueTuple of Tire objects: " + (
            tireInfo.PropertyType == typeof(Tire[]) ||
            tireInfo.PropertyType == typeof(Tuple<Tire, Tire, Tire, Tire>) ||
            tireInfo.PropertyType == typeof((Tire, Tire, Tire, Tire)))
        );
    }

    public static void TestEncapsulation()
    {
        Console.WriteLine("=== Class Car ===");

        string[] membersToTest = new[] { "Make", "Model", "Tires" };
        Type carType = typeof(Car);
        PropertyInfo[] properties = carType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (PropertyInfo property in properties)
        {
            if (Array.IndexOf(membersToTest, property.Name) != -1)
            {
                Console.WriteLine($"{property.Name} encapsulation: " +
                    TestAccessModifierProperty(carType.Name, property.Name, "Public", null) );
            }
        }

        Console.WriteLine("\n=== Class Tire ===");

        Type tireType = typeof(Tire);
        string propertyName = "Brand";
        Console.WriteLine($"{propertyName} encapsulation: " +
            TestAccessModifierProperty(tireType.Name, propertyName, "Public", null));

        propertyName = "Durability";
        Console.WriteLine($"{propertyName} encapsulation: " +
            TestAccessModifierProperty(tireType.Name, propertyName, "Public", "Private"));
    }

    public static void TestEquals()
    {
        Car car1 = new("Ford", "Mustang", "Michelin");
        Car car2 = new("Ford", "Mustang", "Bridgestone");
        Car car3 = new("Ford-Werke GmbH", "Mustang", "Michelin");
        Car car4 = null;
        Car car5 = null;
        object car6 = new Car("Ford", "Mustang", "Michelin");

        Console.WriteLine("Testing method Equals:");
        Console.WriteLine($"car1.Equals(car2): {car1.Equals(car2)}"); // true
        Console.WriteLine($"car1.Equals(car3): {car1.Equals(car3)}"); // false
        Console.WriteLine($"car1.Equals(car4): {car1.Equals(car4)}"); // false
        Console.WriteLine($"car1.Equals(car5): {car1.Equals(car5)}"); // false
        Console.WriteLine($"car6.Equals(car1): {car6.Equals(car1)}"); // true
        Console.WriteLine($"car2.Equals(car3): {car2.Equals(car3)}"); // false
        Console.WriteLine($"car1.Equals(car4): {car1.Equals(car4)}"); // false

        Console.WriteLine("\nTesting the overloaded == and != operators:");
        Console.WriteLine($"car1 == car2: {car1 == car2}"); // true
        Console.WriteLine($"car1 != car2: {car1 != car2}"); // false
        Console.WriteLine($"car1 == car3: {car1 == car3}"); // false
        Console.WriteLine($"car1 == car4: {car1 == car4}"); // false
        Console.WriteLine($"car2 == car3: {car2 == car3}"); // false
        Console.WriteLine($"car1 == car4: {car1 == car4}"); // false
        Console.WriteLine($"car4 == car5: {car4 == car5}"); // true
    }

    public static void TestFunctionality()
    {
        Console.WriteLine("=== Functionality Tire ===");
        Tire tire = new("Michelin");
        Console.WriteLine("Using a new tire...");
        for (int i = 0; i < 6; i++)
        {
            tire.Use();
            Console.WriteLine(" - Durability left:" + tire.Durability);
        }

        Console.WriteLine("\n=== Functionality Tire ===");
        Car car = new("Toyota", "Camry", "Michelin");

        while (car.TryDrive())
        {
            Console.WriteLine("Drove the car");
        }
        Console.WriteLine("Could not drive car; at least one tire should be replaced");
        Console.WriteLine(car.GetTireInfo());

        for (int i = 0; i < 4; i++)
        {
            car.ReplaceTire("Bridgestone", i);
        }
        Console.WriteLine(car.GetTireInfo());

        car.TryDrive();
        car.ReplaceTire(new Tire("Goodyear"), 2);
        car.TryDrive();
        car.ReplaceTire(new Tire("Continental"), 1);

        while (car.TryDrive())
        {
            Console.WriteLine("Drove the car");
        }
        Console.WriteLine("Could not drive car; at least one tire should be replaced");
        Console.WriteLine(car.GetTireInfo());
    }

    private static string TestAccessModifierProperty(string cls, string property, string getTest, string setTest)
    {
        var p = Type.GetType(cls).GetProperty(property,
          BindingFlags.NonPublic |
          BindingFlags.Public |
          BindingFlags.Instance);
        if (p == null)
            return $"Property not found: {property}";

        var flag = false;
        if (getTest != null)
        {
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
        if (setTest != null)
        {
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

    private static string TestAccessModifierMethod(string cls, string method, string modifier)
    {
        var targetType = Type.GetType(cls);
        var methodInfo = targetType?.GetMethod(method,
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance);

        if (methodInfo == null)
            return $"Method not found: {method}";

        bool flag;
        switch (modifier)
        {
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
