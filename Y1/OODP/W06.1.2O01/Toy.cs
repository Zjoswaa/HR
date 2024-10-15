class Toy : IAgeSuitability {
    public string Name { get; }
    protected int MinAge { get; set; }
    protected int MaxAge { get; set; }
    public virtual string AgeSuitability {
        get {
            return $"{MinAge}-{MaxAge}";
        }
    }

    public Toy(string name, int MinAge, int MaxAge) {
        if (MinAge < MaxAge) {
            this.MinAge = MinAge;
            this.MaxAge = MaxAge;
        } else {
            this.MinAge = MaxAge;
            this.MaxAge = MinAge;
        }

        Name = name;
    }

    public override string ToString() {
        return $"{Name} (ages {AgeSuitability})";
    }
}
