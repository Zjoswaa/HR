class Organism {
    public Organism? Offspring { get; }
    public Organism(Organism offspring) => Offspring = offspring;
}
