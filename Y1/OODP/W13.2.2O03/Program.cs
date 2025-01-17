static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Create": TestGenerateLineage(); return;
            case "Mutate": TestRandomMutations(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestGenerateLineage()
    {
        List<string> dnaStrands = new()
        {
            "AGCTA",
            "AGCTA",
            "TGCTA",
            "TGCTAG",
            "ACCTAG",
        };
        Organism organism = Lineage.GenerateLineage(dnaStrands);

        Console.WriteLine("The DNA strands of the lineage:");
        Console.WriteLine(organism.DNAStrand);
        Console.WriteLine(organism.Offspring.DNAStrand);
        Console.WriteLine(organism.Offspring.Offspring.DNAStrand);
        Console.WriteLine(organism.Offspring.Offspring.Offspring.DNAStrand);
        Console.WriteLine(organism.Offspring.Offspring.Offspring.Offspring.DNAStrand);
    }

    public static void TestRandomMutations()
    {
        Random random = new(0);
        double probability = 0.2;

        List<string> dnaStrands = new()
        {
            "AGCTATTGC",
            "AGCTATTGC",
            "AGCTATTGC",
            "AGCTATTGC",
            "AGCTATTGC",
        };
        Organism organism = Lineage.GenerateLineage(dnaStrands);

        Func<string, string> mutateStrand = strand =>
        {
            for (int i = 0; i < strand.Length; i++)
            {
                if (random.NextDouble() < probability)
                {
                    char[] charArray = strand.ToCharArray();
                    charArray[i] = MutateNucleotide(strand[i]);
                    strand = new string(charArray);
                }
            }
            return strand;
        };

        Lineage.IntroduceRandomMutations(organism, mutateStrand);

        Console.WriteLine("The mutated DNA strands of the lineage:");
        Console.WriteLine(organism.DNAStrand);
        Console.WriteLine(organism.Offspring.DNAStrand);
        Console.WriteLine(organism.Offspring.Offspring.DNAStrand);
        Console.WriteLine(organism.Offspring.Offspring.Offspring.DNAStrand);
        Console.WriteLine(organism.Offspring.Offspring.Offspring.Offspring.DNAStrand);
    }

    private static char MutateNucleotide(char nucleotide) => nucleotide switch
    {
        'A' => 'T',
        'T' => 'A',
        'C' => 'G',
        'G' => 'C',
        _ => throw new ArgumentException($"Invalid nucleotide: {nucleotide}")
    };
}
