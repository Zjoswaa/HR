class Patient {
    private static int LastID = 0;

    public readonly string Id;
    public string Name;
    public int Age;

    public Patient(string Name, int Age) {
        LastID++;
        this.Id = $"PAT{LastID:D3}";
        this.Name = Name;
        this.Age = Age;
    }
}
