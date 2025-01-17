static class StandardLINQQueries {
    public static void PrintAllGorillaSeqs(DNADatabase database) {
        foreach (string seq in database.Data.Where(d => d.Organism == "Gorilla").Select(d => d.Sequence)) {
            Console.WriteLine(seq);
        }
    }

    public static void PrintAllFruit(DNADatabase database) { }

    public static void PrintSeqCountPerOrganism(DNADatabase database) { }

    public static void PrintTop3OrganismsWithSimilarSeq(DNADatabase database, string querySequence) { }
}
