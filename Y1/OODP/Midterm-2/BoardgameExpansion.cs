class BoardgameExpansion : Product {
    public string Name {
        get {
            return $"{base.Name} (exp)";
        }
    }

    public BoardgameExpansion(string name, int price) : base(name, price) { }
}
