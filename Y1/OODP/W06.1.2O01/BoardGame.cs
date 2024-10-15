class BoardGame : Toy, IAgeSuitability {
    public string Publisher { get; }

    public BoardGame(string name, string publisher, int MinAge, int MaxAge) : base(name, MinAge, MaxAge) {
        Publisher = publisher;
    }

    public override string ToString() {
        return $"{Name} by {Publisher} (ages {AgeSuitability})";
    }
}
