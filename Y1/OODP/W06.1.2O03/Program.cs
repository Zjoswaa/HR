using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Encapsulation": TestEncapsulation(); return;
            case "Interfaces": TestInterfaces(); return;
            case "Functionality": TestFunctionality(); return;
            default: throw new ArgumentException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestEncapsulation() {
        // CurrentConditionsDisplay
        string className = "CurrentConditionsDisplay";
        Console.WriteLine($"Class {className}");
        string dataMember = "_observable";
        Console.WriteLine($" - Data member {dataMember} encapsulation: "
            + TestAccessModifierField(className, dataMember, "Private"));
        dataMember = "Temperature";
        Console.WriteLine($" - Data member {dataMember} encapsulation: "
            + TestAccessModifierProperty(className, dataMember, "Public", "Private"));
        dataMember = "Humidity";
        Console.WriteLine($" - Data member {dataMember} encapsulation: "
            + TestAccessModifierProperty(className, dataMember, "Public", "Private"));

        // StatisticsDisplay
        className = "StatisticsDisplay";
        Console.WriteLine($"\nClass {className}");
        dataMember = "_observable";
        Console.WriteLine($" - Data member {dataMember} encapsulation: "
            + TestAccessModifierField(className, dataMember, "Private"));
        dataMember = "MinTemperature";
        Console.WriteLine($" - Data member {dataMember} encapsulation: "
            + TestAccessModifierProperty(className, dataMember, "Public", "Private"));
        dataMember = "MaxTemperature";
        Console.WriteLine($" - Data member {dataMember} encapsulation: "
            + TestAccessModifierProperty(className, dataMember, "Public", "Private"));

        // WeatherData
        className = "WeatherData";
        Console.WriteLine($"\nClass {className}");
        dataMember = "_observers";
        Console.WriteLine($" - Data member {dataMember} encapsulation: "
            + TestAccessModifierField(className, dataMember, "Private"));
    }

    public static void TestInterfaces() {
        // Display
        Type interfaceType = typeof(IDisplay);
        Type conditionsType = typeof(CurrentConditionsDisplay);
        Type statisticsType = typeof(StatisticsDisplay);

        Console.WriteLine($"=== {interfaceType.Name} ===");
        Console.WriteLine("Is an interface: " + interfaceType.IsInterface);
        Console.WriteLine("Is implemented by CurrentConditionsDisplay: "
            + interfaceType.IsAssignableFrom(conditionsType));
        Console.WriteLine("Is implemented by StatisticsDisplay: "
            + interfaceType.IsAssignableFrom(statisticsType));
        Console.WriteLine("Method Display has the correct return and parameter types: "
            + CheckMethodSignature(interfaceType, "Display", typeof(void)));

        // IObservable
        interfaceType = typeof(IObservable);
        Type weatherType = typeof(WeatherData);
        Console.WriteLine($"\n=== {interfaceType.Name} ===");
        Console.WriteLine("Is an interface: " + typeof(IObservable).IsInterface);
        Console.WriteLine("Is implemented by WeatherData: "
            + interfaceType.IsAssignableFrom(weatherType));

        Console.WriteLine("Method RegisterObserver has the correct return and parameter types: "
            + CheckMethodSignature(interfaceType, "RegisterObserver", typeof(void), [typeof(IObserver)]));
        Console.WriteLine("Method RemoveObserver has the correct return and parameter types: "
            + CheckMethodSignature(interfaceType, "RemoveObserver", typeof(void), [typeof(IObserver)]));
        Console.WriteLine("Method NotifyObservers has the correct return and parameter types: "
            + CheckMethodSignature(interfaceType, "NotifyObservers", typeof(void)));

        // IObserver
        interfaceType = typeof(IObserver);

        Console.WriteLine($"\n=== {interfaceType.Name} ===");
        Console.WriteLine("Is an interface: " + interfaceType.IsInterface);
        Console.WriteLine("Is implemented by CurrentConditionsDisplay: "
            + interfaceType.IsAssignableFrom(conditionsType));
        Console.WriteLine("Is implemented by StatisticsDisplay: "
            + interfaceType.IsAssignableFrom(statisticsType));
        Console.WriteLine("Method Update has the correct return and parameter types: "
            + CheckMethodSignature(interfaceType, "Update", typeof(void)));
    }

    public static void TestFunctionality() {
        WeatherData weatherData = new();
        CurrentConditionsDisplay currentDisplay = new(weatherData);
        weatherData.RegisterObserver(currentDisplay);
        Console.WriteLine("Adding first set of measurements...");
        weatherData.SetMeasurements(20, 65, 30.4);
        weatherData.SetMeasurements(22, 70, 29.2);
        weatherData.SetMeasurements(18, 90, 29.4);

        Console.WriteLine("\nAdding second set of measurements...");
        StatisticsDisplay statisticsDisplay = new(weatherData);
        weatherData.RegisterObserver(statisticsDisplay);
        weatherData.SetMeasurements(15, 70, 29.0);
        weatherData.SetMeasurements(20, 68, 28.7);
        weatherData.SetMeasurements(13, 67, 27.9);

        foreach (IObserver observer in new List<IObserver>() { currentDisplay, statisticsDisplay }) {
            observer.Update();
        }

        foreach (IDisplay display in new List<IDisplay>() { currentDisplay, statisticsDisplay }) {
            display.Display();
        }
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
