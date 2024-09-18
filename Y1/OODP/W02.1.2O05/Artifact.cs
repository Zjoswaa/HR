class Artifact {
    public double Rarity;
    public double Condition;

    public Artifact(double Rarity, double Condition) {
        this.Rarity = Rarity;
        this.Condition = Condition;
    }

    public double GetValue() {
        return this.Rarity * this.Condition;
    }

    public string Appraise() {
        return $"Value: {this.GetValue()}";
    }

    public bool isEqualTo(Artifact Artifact) {
        return this.Rarity == Artifact.Rarity && this.Condition == Artifact.Condition;
    }
}
