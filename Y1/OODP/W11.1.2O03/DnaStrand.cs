static class DnaStrand {
    public static string ComplementaryStrand(string Strand) {
        string Complementary = "";
        foreach (char c in Strand) {
            if (c == 'A') {
                Complementary += 'T';
            } else if (c == 'C') {
                Complementary += 'G';
            } else if (c == 'G') {
                Complementary += 'C';
            } else if (c == 'T') {
                Complementary += 'A';
            }
        }
        return new string(Complementary.Reverse().ToArray());
    }

    public static bool IsValidDnaStrand(string Strand) {
        foreach (char c in Strand) {
            if (c != 'A' && c != 'T' && c != 'C' && c != 'G') {
                return false;
            }
        }
        return true;
    }

    public static string Transcribe(string Strand) {
        return new string(Strand.Replace('T', 'U'));
    }

    public static int HammingDistance(string First, string Second) {
        if (First.Length != Second.Length) {
            return -1;
        }
        int Counter = 0;
        for (int i = 0; i < First.Length; i++) {
            if (First.ElementAt(i) != Second.ElementAt(i)) {
                Counter++;
            }
        }
        return Counter;
    }
}
