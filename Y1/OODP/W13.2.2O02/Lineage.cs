static class Lineage {
    public static Organism? GenerateLineage(int generations) {
        if (generations <= 0) {
            return null;
        }

        return new Organism(GenerateLineage(generations - 1)!);
    }

    public static int CountLineageLength(Organism organism) {
        if (organism.Offspring is null) {
            return 1;
        }
        return CountLineageLength(organism.Offspring) + 1;
    }
}
