class Car {
    public string Make { get; set; } = "unknown";
    public string Model { get; set; } = "unknown";
    public int Year { get; set; }
    public string Description {
        get {
            return $"{Year} {Make} {Model}";
        }
    }
}
