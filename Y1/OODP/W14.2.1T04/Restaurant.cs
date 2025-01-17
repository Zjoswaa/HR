class Restaurant {
    public string Name { get; set; }
    public string City { get; set; }
    public int OpeningYear { get; set; }

    public override string ToString() {
        return $"Name: {Name}, City: {City}, OpeningYear: {OpeningYear}";
    }
}
