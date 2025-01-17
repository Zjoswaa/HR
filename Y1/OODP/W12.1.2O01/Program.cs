using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Encapsulation":
                TestEncapsulation();
                return;
            case "Min":
                TestMinimum();
                return;
            default: throw new ArgumentException();
        }
    }

    public static void TestEncapsulation() {
        string className = "ArrayUtils";
        Console.WriteLine($"{className} members encapsulation:");
        Console.WriteLine(
            " - Method OwnerName: " +
            TestAccessModifierMethod(className, "RecMinimum", "Private"));
    }

    public static void TestMinimum() {
        int[] arr1 = new int[] { 5, 3, 10, -4, 6 };
        int min1 = ArrayUtils.FindMinimum(arr1);
        Console.WriteLine(min1);

        int[] arr2 = new int[] { 4, 1, 0 };
        int min2 = ArrayUtils.FindMinimum(arr2);
        Console.WriteLine(min2);

        int[] arr3 = new int[] { -3, -2, -1, 0, 1, 2, 3 };
        int min3 = ArrayUtils.FindMinimum(arr3);
        Console.WriteLine(min3);
    }

    private static string TestAccessModifierMethod(string cls, string method, string modifier) {
        var targetType = Type.GetType(cls);
        var methodInfo = targetType?.GetMethod(method,
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Static);

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
