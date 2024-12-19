using System.Reflection;

public class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Encapsulation": TestEncapsulation(); return;
            case "Plus": TestOverloadPlus(); return;
            case "Times": TestOverloadTimes(); return;
            default: throw new ArgumentException();
        }
    }

    static void TestEncapsulation()
    {
        Console.WriteLine($"Robot constructor encapsulation: "
            + TestAccessModifierConstructor(
                "Robot",
                new[] { ("Private", new Type[] { typeof(int), typeof(bool) })}));
        Console.WriteLine($"Property Power encapsulation: "
            + TestAccessModifierProperty("Robot", "Power", "Public", "Private"));
        Console.WriteLine($"Property IsFused encapsulation: "
            + TestAccessModifierProperty("Robot", "IsFused", "Public", "Private"));


        Robot robot1 = new(-5);
        Robot robot2 = new(-10);
        Console.WriteLine("\nDoes the robot's Power have a minimum of 0?");
        Console.WriteLine($"- Robot robot1 Power: {robot1.Power}");
        Console.WriteLine($"- Robot robot1 Power: {robot2.Power}");
    }

    static void TestOverloadPlus()
    {
        Robot robotA0 = null;
        Robot robotA1 = null;
        Robot robotB0 = new Robot(3);
        Robot robotB1 = new Robot(5);
        Robot robotB2 = new Robot(10);
        Console.WriteLine($"robotA0 + robotA1: Power = {(robotA0 + robotA1)?.Power}");
        Console.WriteLine($"robotB1 + robotA1: Power = {(robotB1 + robotA1).Power}");
        Console.WriteLine($"robotA0 + robotB0: Power = {(robotA0 + robotB0).Power}");
        Console.WriteLine($"robotB0 + robotB1: Power = {(robotB0 + robotB1).Power}");
        Console.WriteLine($"robotB1 + robotB2: Power = {(robotB1 + robotB2).Power}");
    }

    static void TestOverloadTimes()
    {
        Robot robotA0 = null;
        Robot robotA1 = null;
        Robot robotB0 = new Robot(3);
        Robot robotB1 = new Robot(5);
        Robot robotB2 = new Robot(10);
        Console.WriteLine($"robotA0 * robotA1: Power = {(robotA0 * robotA1)?.Power}");
        Console.WriteLine($"robotB1 * robotA1: Power = {(robotB1 * robotA1).Power}");
        Console.WriteLine($"robotA0 * robotB0: Power = {(robotA0 * robotB0).Power}");
        Console.WriteLine($"robotB0 * robotB1: Power = {(robotB0 * robotB1).Power}");
        Console.WriteLine($"robotB1 * robotB2: Power = {(robotB1 * robotB2).Power}");

        Robot robotC0 = robotB0 * robotB1;
        Console.WriteLine($"\nrobotC0 Power: {robotC0.Power}");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"robotC0 attacks with {robotC0.Attack()} Power!");
        }
        Console.WriteLine($"robotC0 Power left: {robotC0.Power}");
    }

    static string TestAccessModifierConstructor(string cls, (string accessModifier, Type[] parameterTypes)[] constructorsToCheck)
    {
        var type = Type.GetType(cls);
        if (type == null)
            return $"Type not found: {cls}";

        var constructors = type.GetConstructors(
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        if (constructors.Length == 0)
            return "No constructors found for the type.";

        foreach (var (accessModifier, parameterTypes) in constructorsToCheck)
        {
            var constructor = Array.Find(constructors, c => ConstructorMatches(c, accessModifier, parameterTypes));

            if (constructor == null)
                return $"Constructor with access modifier '{accessModifier}' and parameter types '{string.Join(", ", parameterTypes.Select(t => t.Name))}' not found.";

            constructors = constructors.Except(new[] { constructor }).ToArray();
        }

        // Check if there are any remaining constructors with different access modifiers
        foreach (var constructor in constructors)
        {
            if (!constructor.IsPublic && !constructor.IsFamily && !constructor.IsPrivate)
                return "Incorrect.";
        }

        return "Correct!";
    }

    static bool ConstructorMatches(ConstructorInfo constructor, string accessModifier, Type[] parameterTypes)
    {
        if (accessModifier == "Public")
            return constructor.IsPublic && ParametersMatch(constructor, parameterTypes);
        else if (accessModifier == "Family")
            return constructor.IsFamily && ParametersMatch(constructor, parameterTypes);
        else if (accessModifier == "Private")
            return constructor.IsPrivate && ParametersMatch(constructor, parameterTypes);

        return false;
    }

    static bool ParametersMatch(ConstructorInfo constructor, Type[] parameterTypes)
    {
        var constructorParameters = constructor.GetParameters();
        if (constructorParameters.Length != parameterTypes.Length)
            return false;

        for (var i = 0; i < constructorParameters.Length; i++)
        {
            if (constructorParameters[i].ParameterType != parameterTypes[i])
                return false;
        }

        return true;
    }

    static string TestAccessModifierProperty(string cls, string property, string getTest, string setTest)
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
}
