public class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Equals": TestEquals(); return;
            case "Batch1": TestBatch1(); return;
            case "Batch2": TestBatch2(); return;
            default: throw new ArgumentException();
        }
    }

    static void TestEquals()
    {
        Animal a1 = new("Elephant", 7);
        Animal a2 = new("Elephant", 7);
        Animal a3 = new("Elephant", 3);
        Animal a4 = new("Lion", 7);
        Animal a5 = null;
        Animal a6 = new Bird("Parrot", 7, 250);
        Bird b1 = new Bird("Parrot", 7, 250);

        Console.WriteLine($"a1.Equals(a2): " + a1.Equals(a2)); //true
        Console.WriteLine($"a1.Equals(a3): " + a1.Equals(a3)); //true
        Console.WriteLine($"a1.Equals(a4): " + a1.Equals(a4)); //false
        Console.WriteLine($"a1.Equals(a5): " + a1.Equals(a5)); //false
        Console.WriteLine($"a3.Equals(a4): " + a3.Equals(a4)); //false
        Console.WriteLine($"a1.Equals(b1): " + a1.Equals(b1)); //false
        Console.WriteLine($"a6.Equals(b1): " + a6.Equals(b1)); //true

        Console.WriteLine();

        Console.WriteLine($"a1 == a2: " + (a1 == a2)); //true
        Console.WriteLine($"a1 == a3: " + (a1 == a3)); //true
        Console.WriteLine($"a1 == a4: " + (a1 == a4)); //false
        Console.WriteLine($"a1 == a5: " + (a1 == a5)); //false
        Console.WriteLine($"a3 == a4: " + (a3 == a4)); //false
        Console.WriteLine($"a4 == a3: " + (a4 == a3)); //false
        Console.WriteLine($"a4 == a4: " + (a4 == a4)); //true
        Console.WriteLine($"a1 == b1: " + (a1 == b1)); //false
        Console.WriteLine($"a6 == b1: " + (a6 == b1)); //true
    }

    static void TestBatch1()
    {
        Animal[][] animalsJaggedArr = new Animal[][] {
            new Animal[] { new Animal("Giraffe", 8), new Animal("Lion", 5), new Animal("Tiger", 3) },
            new Animal[] { new Animal("Lion", 3), new Animal("Lion", 3) },
            new Animal[] { new Animal("Elephant", 10), new Animal("Giraffe", 8) },
            new Animal[] { new Animal("Lion", 5) }};

        Animal searchAnimal = new("Lion", 3);

        (int sameSpeciesCount, int sameSpeciesAgeCount) countsTuple = AnimalCounter.CountOccurrences(animalsJaggedArr, searchAnimal);
        Console.WriteLine($"Occurrences of {searchAnimal.Species}: {countsTuple.sameSpeciesCount}");
        Console.WriteLine($"Occurrences of {searchAnimal.Species}, Age: {searchAnimal.Age}: {countsTuple.sameSpeciesAgeCount}");
    }

    static void TestBatch2()
    {
        Animal[][] animalsJaggedArr = new Animal[][] {
            new Animal[] { new Animal("Lion", 5), new Bird("Parrot", 7, 250) },
            new Animal[] { new Bird("Parrot", 4, 200), new Animal("Elephant", 2), new Animal("Tiger", 9) },
            new Animal[] { new Animal("Elephant", 7) }};

        Animal searchAnimal = new Bird("Parrot", 7, 250);
        (int sameSpeciesCount, int sameSpeciesAgeCount) countsTuple = AnimalCounter.CountOccurrences(animalsJaggedArr, searchAnimal);

        Console.WriteLine($"Occurrences of {searchAnimal.Species}: {countsTuple.sameSpeciesCount}");
        Console.WriteLine($"Occurrences of {searchAnimal.Species}, Age: {searchAnimal.Age}: {countsTuple.sameSpeciesAgeCount}");
    }
}
