using System.Reflection;
public class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Equal": TestEquals(); return;
            case "Where": TestWhere(); return;
            default: throw new ArgumentException();
        }
    }

    static void TestEquals()
    {
        Dog dog1 = new("Fido", 5, "Bill");
        Dog dog2 = new("Rex", 2, "Bob");
        Dog dog3 = new("Rex", 2, "Bea");
        Dog dog4 = new("Fido", 2, "Ben");
        Dog nullDog = null;

        Console.WriteLine("Test IEquatable<Animal> implementation");
        Console.WriteLine("dog1.Equals(dog2): {0}", dog1.Equals(dog2)); //False
        Console.WriteLine("dog1.Equals(dog4): {0}", dog1.Equals(dog4)); //False
        Console.WriteLine("dog2.Equals(nullDog): {0}", dog2.Equals(nullDog)); //False
        Console.WriteLine("dog2.Equals(dog3): {0}", dog2.Equals(dog3)); //True

        Console.WriteLine();
        Console.WriteLine("Test ==");
        Console.WriteLine("dog1 == dog2: {0}", dog1 == dog2); //False
        Console.WriteLine("dog1 == dog4: {0}", dog1 == dog4); //False
        Console.WriteLine("dog2 == nullDog: {0}", dog2 == nullDog); //False
        Console.WriteLine("dog2 == dog3: {0}", dog2 == dog3); //True
        Console.WriteLine("nullDog == null: {0}", nullDog == null); //True
        Console.WriteLine();
        
        Cat cat1 = new("Fluffy", 3, "Sara");
        Cat cat2 = new("Mittens", 2, "Nina");
        Cat nullCat = null;
        object cat3 = new Cat("Fluffy", 3, "Dave");
        object cat4 = new Cat("Mittens", 1, "Rob");

        Console.WriteLine("Test !=");
        Console.WriteLine("cat1 != cat1: {0}", cat1 != cat1); //False
        Console.WriteLine("nullCat != null: {0}", nullCat != null); //False
        Console.WriteLine("cat1 != cat2: {0}", cat1 != cat2); //True
        Console.WriteLine("cat1 != null: {0}", cat1 != null); //True
        Console.WriteLine();

        Console.WriteLine("Test Equals(object)");
        Console.WriteLine("cat1.Equals(cat4): {0}", cat1.Equals(cat4)); //False
        Console.WriteLine("cat3.Equals(\"cat\"): {0}", cat3.Equals("cat")); //False
        Console.WriteLine("cat1.Equals(cat3): {0}", cat1.Equals(cat3)); //True
        Console.WriteLine();
    }

    static void TestWhere()
    {
        CheckMethodConstraints("AddAnimal");
        CheckMethodConstraints("SearchAnimal");
        Console.WriteLine();
        TestFunctionality();
    }

    private static void CheckMethodConstraints(string MethodName)
    {

        MethodInfo methodInfo = typeof(Shelter).GetMethod(MethodName);
        if (methodInfo is null)
        {
            Console.WriteLine($"Method {MethodName} does not exist");
            return;
        }

        ParameterInfo[] parameters = methodInfo.GetParameters();
        foreach (ParameterInfo parameter in parameters)
        {
            if (parameter.ParameterType.IsGenericParameter)
            {
                Type[] constraints = parameter.ParameterType.GetGenericParameterConstraints();

                if (Array.Exists(constraints, type => type == typeof(Animal)) &&
                    Array.Exists(constraints, type => type == typeof(IPet)))
                {
                    Console.WriteLine($"Method {MethodName} has the correct generic constraints");
                }
                else
                {
                    Console.WriteLine($"Method {MethodName} does not have the required generic constraints");
                }
            }
        }
    }


    static void TestFunctionality()
    {
        Shelter.AddAnimal(new Dog("Fido", 1, "Mike"));
        Shelter.AddAnimal(new Cat("Sylvester", 2, "Rita"));
        Shelter.AddAnimal(new Cat("Fluffy", 3, "Unknown"));
        Shelter.AddAnimal(new Cat("Fluffy", 2, "Lisa"));

        List<Dog> dogsToFind = new() {
            new Dog("Fido", 1, "Mike"), // yes
            new Dog("Sparky", 5, "Tim"), // no
            new Dog("Fluffy", 3, "Unknown") //no
        };
        foreach (Dog d in dogsToFind)
        {
            Dog dog = Shelter.SearchAnimal(d);

            if (dog is null)
                Console.WriteLine($"Dog found: name: {d.Name}, age: {d.Age}");
            else
                Console.WriteLine($"Dog not found: name: {d.Name}, age: {d.Age}");
        }
        System.Console.WriteLine();

        List<Cat> catsToFind = new() {
            new Cat("Fluffy", 3, "Unknown"), // yes
            new Cat("Sylvester", 2, "Rita"), // yes
            new Cat("Fido", 1, "Unknown") // no
        };
        foreach (Cat c in catsToFind)
        {
            Cat cat = Shelter.SearchAnimal(c);

            if (cat is null)
                Console.WriteLine($"Cat found: name: {c.Name}, age: {c.Age}");
            else
                Console.WriteLine($"Cat not found: name: {c.Name}, age: {c.Age}");
        }
    }
}
