public class Program {
    public static void Main(string[] args) {
        switch (args[1]) {
            case "IEquatable":
                TestIEquatable();
                return;
            case "Equals":
                TestEquals();
                return;
            default: throw new ArgumentException();
        }
    }

    public static void TestIEquatable() {
        Type personType = typeof(Person);
        Type equatableType = typeof(IEquatable<>).MakeGenericType(personType);
        bool implementsEquatable = equatableType.IsAssignableFrom(personType);

        Console.WriteLine("Person implements IEquatable<Person>: " + implementsEquatable);
    }

    public static void TestEquals() {
        var people = new Person[] {
            new Person { Name = "John", Age = 30 },
            new Person { Name = "John", Age = 30 },
            new Person { Name = "John", Age = 25 },
            new Person { Name = "Jane", Age = 30 },
        };

        for (int i = 0; i < people.Length; i++) {
            for (int j = i + 1; j < people.Length; j++) {
                Person p1 = people[i];
                Person p2 = people[j];
                Console.WriteLine(
                    $"{p1} equals {p2}: {p1.Equals(p2)}");
            }
        }
    }
}
