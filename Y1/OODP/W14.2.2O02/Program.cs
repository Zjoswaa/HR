static class Program
{
    public static DNADatabase Database { get; } = new(new() {
        new DNA("SeqHoSa1", "Homo sapiens", "TCGATGAGGCTTACGGGTAG"),
        new DNA("SeqHoSa2", "Homo sapiens", "ATCGTCCGATGGTACGATGC"),
        new DNA("SeqHoSa3", "Homo sapiens", "GGTACCTAAGCGTACAGCGA"),
        new DNA("SeqHoSa4", "Homo sapiens", "CCGTGTATCGACTAGACGTC"),
        new DNA("SeqGoGo1", "Gorilla gorilla", "GGTACCTAACCGTACAGCGA"),
        new DNA("SeqGoGo2", "Gorilla gorilla", "ATCGTCCGATGGTTCGATGC"),
        new DNA("SeqGoGo3", "Gorilla gorilla", "TCGATGAGGCTTACGGCTAG"),
        new DNA("SeqGoGo4", "Gorilla gorilla", "CGCTGTATCGACTAGACGTC"),
        new DNA("SeqVuVu1", "Vulpes vulpes", "AGTGCATGGTAGCTCGCTAA"),
        new DNA("SeqVuVu2", "Vulpes vulpes", "GGTACCTAACCGTACAGCGT"),
        new DNA("SeqVuVu3", "Vulpes vulpes", "TCGATCAGGCATACCGCTAG"),
        new DNA("SeqMaPu1", "Malus pumila", "GCTAGCGTTGCTAGCGTAGC"),
        new DNA("SeqMaPu2", "Malus pumila", "TCGTTCAGGCATAGCGGTTG"),
        new DNA("SeqMuPa1", "Musa paradisiaca", "GCTAGCGTAGCTAGCGTAGC"),
        new DNA("SeqMuPa2", "Musa paradisiaca", "TCGTTCAGGCATAGCGGTTG"),
        new DNA("SeqCiRe1", "Citrus reticulata", "TGGTTCAGGCATAGCGGTTG"),
        new DNA("SeqCiRe2", "Citrus reticulata", "GCTAGCGTAGCTGGCGTAGC"),
        new DNA("SeqEsCo1", "Escherichia coli", "TCGTTCACGCATAGCAGATC"),
        new DNA("SeqEsCo2", "Escherichia coli", "TCGTAGCTAGCGTACGTAGC"),
        new DNA("SeqEsCo3", "Escherichia coli", "ATCGTAGCTAGCGTAGCTAG"),
    });

    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Gorilla": TestPrintGorillaSeqs(); return;
            case "Fruit": TestPrintFruit(); return;
            case "Count": TestPrintSeqCount(); return;
            case "Top3": TestPrintTop3(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestPrintGorillaSeqs()
    {
        StandardLINQQueries.PrintAllGorillaSeqs(Database);
    }

    public static void TestPrintFruit()
    {
        StandardLINQQueries.PrintAllFruit(Database);
    }

    public static void TestPrintSeqCount()
    {
        StandardLINQQueries.PrintSeqCountPerOrganism(Database);
    }

    public static void TestPrintTop3()
    {
        string querySequence = "TCGATGAGGCTTACGGGTAG";
        StandardLINQQueries.PrintTop3OrganismsWithSimilarSeq(Database, querySequence);

        Console.WriteLine();

        querySequence = "GCTAGCGTTGCTAGCGTAGC";
        StandardLINQQueries.PrintTop3OrganismsWithSimilarSeq(Database, querySequence);
    }
}
