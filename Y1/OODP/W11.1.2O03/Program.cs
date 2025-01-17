static class Program {
    static void Main(string[] args) {
        string[] validDnaStrings = new[] {
            "ACTGAGCTAGCTAGCTAGCTAGCTAG",
            "GCTAGCTAGCTAGCTAGCTAGCTAGC",
            "GCATGCATGCATGCATCG",
            "CGATGCATGCATGCATGC",
        };
        string[] invalidDnaStrings = new[] {
            "ACTGAGCTAGCTAGCTAGCTAGCTAG$",
            "AACCGGTTU",
            "CGATG CATGCATGCATGC",
            "ACGTACGTACGTAXCGT",
        };

        switch (args[1]) {
            case "Complement":
                TestComplementaryStrand(validDnaStrings);
                return;
            case "Valid":
                TestIsValidDnaStrand(validDnaStrings.Concat(invalidDnaStrings).ToArray());
                return;
            case "Transcribe":
                TestTranscribe(validDnaStrings);
                return;
            case "Hamming":
                TestHammingDistance(validDnaStrings);
                return;
            default: throw new ArgumentException();
        }
    }

    public static void TestComplementaryStrand(string[] dnaStrings) {
        foreach (var dnaString in dnaStrings) {
            Console.WriteLine("Strand: " + dnaString);
            Console.WriteLine("Complementary: " + DnaStrand.ComplementaryStrand(dnaString));
        }
    }

    public static void TestIsValidDnaStrand(string[] dnaStrings) {
        foreach (var dnaString in dnaStrings) {
            Console.WriteLine($"Strand {dnaString} is valid: {DnaStrand.IsValidDnaStrand(dnaString)}");
        }
    }

    public static void TestTranscribe(string[] dnaStrings) {
        foreach (var dnaString in dnaStrings) {
            Console.WriteLine($"Strand {dnaString} transcribed: {DnaStrand.Transcribe(dnaString)}");
        }
    }

    public static void TestHammingDistance(string[] dnaStrings) {
        for (int i = 0; i < dnaStrings.Length - 1; i++) {
            Console.WriteLine($"Strands:");
            Console.WriteLine($" - {dnaStrings[i]}");
            Console.WriteLine($" - {dnaStrings[i + 1]}");
            Console.WriteLine($"Hamming distance: {DnaStrand.HammingDistance(dnaStrings[i], dnaStrings[i + 1])}\n");
        }
    }
}