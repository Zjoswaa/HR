class Movie : IAgeSuitability {
    public string Title { get; }
    private int MinAge { get; set; }
    private int MaxAge { get; set; }
    public string AgeSuitability {
        get {
            return $"{MinAge}-{MaxAge}";
        }
    }

    public Movie(string title, int MinAge, int MaxAge) {
        if (MinAge < MaxAge) {
            this.MinAge = MinAge;
            this.MaxAge = MaxAge;
        } else {
            this.MinAge = MaxAge;
            this.MaxAge = MinAge;
        }

        Title = title;
    }

    public override string ToString() {
        return $"Movie {Title} (ages {AgeSuitability})";
    }
}
