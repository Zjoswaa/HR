class Lego : Toy, IAgeSuitability {
    public bool IsBuilt { get; private set; } = false;
    public override string AgeSuitability {
        get {
            return $"{MinAge}+";
        }
    }

    public Lego(string name, int MinAge) : base(name, MinAge, 99) { }

    public void Build() => IsBuilt = true;
    public void Disassemble() => IsBuilt = false;

    public override string ToString() {
        return $"{(IsBuilt ? "Built " : "")}{Name} (ages {AgeSuitability})";
    }
}
