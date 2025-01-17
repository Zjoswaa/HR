class Organism {
    public Organism? Offspring { get; }
    public string DNAStrand { get; set; }

    public Organism(Organism offspring, string dnaStrand) {
        Offspring = offspring;
        DNAStrand = dnaStrand;
    }
}
