class Animal : IEquatable<Animal> {
    public string Species { get; set; }
    public int Age { get; set; }

    public Animal(string Species, int Age) {
        this.Species = Species;
        this.Age = Age;
    }
    
    public bool Equals(Animal? other) {
        return other is not null && this.Species == other.Species;
    }

    public override bool Equals(object? other) {
        return other is Animal && Equals(other);
    }

    public static bool operator ==(Animal a1, Animal a2) {
        return a1.Equals(a2);
    }

    public static bool operator !=(Animal a1, Animal a2) {
        return !(a1 == a2);
    }
}
