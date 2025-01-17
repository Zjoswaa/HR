class OrganismSimilarity {
    public string Organism { get; set; }
    public double Similarity { get; set; }

    public OrganismSimilarity(string organism, double similarity) {
        Organism = organism;
        Similarity = similarity;
    }
}
