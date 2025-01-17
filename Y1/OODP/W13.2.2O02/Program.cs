static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Create":
                TestGenerateLineage();
                return;
            case "Count":
                TestCountLineageLength();
                return;
            default: throw new ArgumentException();
        }
    }

    public static void TestGenerateLineage() {
        Organism lineageOfLength2 = Lineage.GenerateLineage(2);
        Console.WriteLine("The first lineage has a length of 2: " +
                          (lineageOfLength2.Offspring.Offspring is null));
        Organism lineageOfLength4 = Lineage.GenerateLineage(4);
        Console.WriteLine("The second lineage has a length of 4: " +
                          (lineageOfLength4.Offspring.Offspring.Offspring.Offspring is null));
    }

    public static void TestCountLineageLength() {
        Organism lineageOfLength2 = Lineage.GenerateLineage(2);
        Console.WriteLine("The first lineage has a length of: " +
                          Lineage.CountLineageLength(lineageOfLength2));
        Organism lineageOfLength4 = Lineage.GenerateLineage(4);
        Console.WriteLine("The first lineage has a length of: " +
                          Lineage.CountLineageLength(lineageOfLength4));
    }
}
