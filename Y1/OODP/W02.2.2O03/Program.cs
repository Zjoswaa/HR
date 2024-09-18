class Program {
    public static void Main() {
        List<DNA> DNAs = new() {
            new DNA("ACGT"),
            new DNA("GCTTAC"),
            new DNA("CGTTAGCTT"),
            new DNA("TACA")
        };

        Console.Write("What is the minimum sequence length: ");
        int SequenceLength = int.Parse(Console.ReadLine());

        Console.WriteLine("This is the filtered list:");
        foreach (DNA DNA in DNAs) {
            if (DNA.Seq.Length >= SequenceLength) {
                Console.WriteLine(DNA.Seq);
            }
        }
    }
}
