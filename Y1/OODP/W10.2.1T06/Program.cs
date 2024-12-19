static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "IEquatable": TestIEquatable(); return;
            case "Equals": TestEquals(); return;
            case "EqualsObj": TestEqualsObj(); return;
            case "Operator": TestOperatorOverloadingEquals(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestIEquatable()
    {
        Type personType = typeof(Person);
        Type equatableType = typeof(IEquatable<>).MakeGenericType(personType);
        bool implementsIEquatable = equatableType.IsAssignableFrom(personType);

        Console.WriteLine("Person implements IEquatable<Person>: " + implementsIEquatable);
    }

    public static void TestEquals()
    {
        Person[] people = [
            new() { Name = "John", Age = 30 },
            new() { Name = "John", Age = 25 },
            new() { Name = "Jane", Age = 30 },
        ];

        foreach (Person p1 in people)
        {
            foreach (Person p2 in people)
            {
                Console.WriteLine(
                    $"{p1} equals {p2}: {p1.Equals(p2)}");
            }
        }
    }

    public static void TestEqualsObj()
    {
        var objects = new object[]
        {
            new Person { Name = "Max", Age = 5 },
            new Person { Name = "Max", Age = 5 },
            new Person { Name = "May", Age = 25 },
            new Student { Name = "May", Age = 25, StudentId = "01234" },
            new Dog { Name = "Max", Age = 5 },
            null!,
        };

        foreach (object o1 in objects)
        {
            foreach (object o2 in objects)
            {
                if (o1 is null || o2 is null)
                {
                    Console.WriteLine("Object is null. Skipping...");
                }
                else if ((o1 is Person && o2 is Person) ||
                    (o1 is Student && o2 is Person) ||
                    (o1 is Person && o2 is Student))
                {
                    Console.WriteLine($"{o1.GetType().Name} {o1} equals {o2.GetType().Name} {o2}: {o1.Equals(o2)}");
                }
                else if (o1 is Dog || o2 is Dog)
                {
                    Console.WriteLine($"{o1.GetType().Name} {o1} does not equal {o2.GetType().Name} {o2}");
                }
            }
        }
    }

    public static void TestOperatorOverloadingEquals()
    {
        Person p1 = new() { Name = "Max", Age = 5 };
        Person p2 = new() { Name = "Max", Age = 5 };
        Person p3 = new() { Name = "May", Age = 25 };
        Person p4 = new() { Name = "May", Age = 25 };
        Person p5 = null!;
        Person p6 = null!;
        Student s1 = new() { Name = "May", Age = 25, StudentId = "01234" };

        Console.WriteLine($"p1 == p2: " + (p1 == p2));
        Console.WriteLine($"p1 == p3: " + (p1 == p3));
        Console.WriteLine($"p3 == p4: " + (p3 == p4));
        Console.WriteLine($"p2 == p5: " + (p2 == p5));
        Console.WriteLine($"p6 == p1: " + (p6 == p1));
        Console.WriteLine($"p5 == p6: " + (p5 == p6));
        Console.WriteLine($"p3 == s1: " + (p3 == s1));

        Console.WriteLine();

        Console.WriteLine($"p1 != p2: " + (p1 != p2));
        Console.WriteLine($"p1 != p3: " + (p1 != p3));
        Console.WriteLine($"p3 != p4: " + (p3 != p4));
        Console.WriteLine($"p2 != p5: " + (p2 != p5));
        Console.WriteLine($"p6 != p1: " + (p6 != p1));
        Console.WriteLine($"p5 != p6: " + (p5 != p6));
        Console.WriteLine($"p3 != s1: " + (p3 != s1));
    }
}
