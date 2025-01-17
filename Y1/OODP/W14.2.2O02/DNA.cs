class DNA {
    public string ID { get; }
    public string Organism { get; }
    public string Sequence { get; }

    public DNA(string id, string organism, string sequence) {
        ID = id;
        Organism = organism;
        Sequence = sequence;
    }

    public static double CalculateSimilarity(string strand1, string strand2) {
        if (strand1.Length != strand2.Length) {
            throw new ArgumentException("DNA strands must be of equal length");
        }

        int matchingPairs = 0;

        for (int i = 0; i < strand1.Length; i++) {
            if (strand1[i] == strand2[i]) {
                matchingPairs++;
            }
        }

        double similarity = (double)matchingPairs / strand1.Length;
        return similarity;
    }
}
