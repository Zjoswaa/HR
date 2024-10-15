using System.Reflection;

static class Program {
    public static void Main(string[] args) {
        switch (args[1]) {
            case "Inheritance": TestInheritance(); return;
            case "Encapsulation": TestEncapsulation(); return;
            case "Functionality": TestFunctionality(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestInheritance() {
        // Inheritance Popup to ConfirmPopup
        Type baseType = typeof(Popup);
        Type derivedType = typeof(ConfirmPopup);
        Console.WriteLine("ConfirmPopup is derived from Popup: "
            + derivedType.IsSubclassOf(baseType));

        // Method Display
        string methodName = "Display";
        Type[] parameterTypes = { };
        MethodInfo baseMethod = baseType.GetMethod(methodName, parameterTypes);
        MethodInfo derivedMethod = derivedType.GetMethod(methodName, parameterTypes);

        Console.WriteLine($"Method {methodName} is overridden in ConfirmPopup: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));

        // Inheritance Popup to ProgressPopup
        baseType = typeof(Popup);
        derivedType = typeof(ProgressPopup);
        Console.WriteLine("\nProgressPopup is derived from Popup: "
            + derivedType.IsSubclassOf(baseType));

        // Method Display
        derivedMethod = derivedType.GetMethod(methodName, parameterTypes);
        Console.WriteLine($"Method {methodName} is overridden in ProgressPopup: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));
    }

    public static void TestEncapsulation() {
        // class CoolApplication
        string className = "CoolApplication";
        Console.WriteLine($"{className} members encapsulation:");

        string methodName = "CreateApplication";
        Console.WriteLine($" - Method {methodName}: " +
        TestAccessModifierMethod(className, methodName, "Private"));

        methodName = "HandleConfirm";
        Console.WriteLine($" - Method {methodName}: " +
        TestAccessModifierMethod(className, methodName, "Private"));

        methodName = "FormatHardDrive";
        Console.WriteLine($" - Method {methodName}: " +
        TestAccessModifierMethod(className, methodName, "Private"));

        // class Button
        className = "Button";
        Console.WriteLine($"\n{className} members encapsulation:");

        string fieldName = "_sender";
        Console.WriteLine($" - Field {fieldName}: " +
        TestAccessModifierField(className, fieldName, "Private"));

        fieldName = "_myAction";
        Console.WriteLine($" - Field {fieldName}: " +
        TestAccessModifierField(className, fieldName, "Private"));

        // class ConfirmPopup
        className = "ConfirmPopup";
        Console.WriteLine($"\n{className} members encapsulation:");
        methodName = "CreateButtons";
        Console.WriteLine($" - Method {methodName}: " +
        TestAccessModifierMethod(className, methodName, "Private"));

        // class ProgressPopup
        className = "ProgressPopup";
        Console.WriteLine($"\n{className} members encapsulation:");

        fieldName = "_progress";
        Console.WriteLine($" - Field {fieldName}: " +
        TestAccessModifierField(className, fieldName, "Private"));

        fieldName = "_progressBar";
        Console.WriteLine($" - Field {fieldName}: " +
        TestAccessModifierField(className, fieldName, "Private"));
    }

    public static void TestFunctionality() {
        CoolApplication app = new();

        Console.WriteLine("There is a button labelled " +
            $"'{app.DoSomethingBtn.Text}'. Let's press it.\n");
        app.DoSomethingBtn.Press();
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
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance);

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
