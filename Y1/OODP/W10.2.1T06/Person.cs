class Person : IEquatable<Person> {
    public string Name { get; set; }
    public int Age { get; set; }

    public bool Equals(Person? other) {
        if (other == null) {
            return false;
        }

        return this.Name == other.Name && this.Age == other.Age;
    }

    public override bool Equals(object? obj) {
        if (obj == null || !(obj is Person)) {
            return false;
        }
        return this.Equals(obj as Person);
    }

    public static bool operator ==(Person p1, Person p2) {
        if (p1 is null || p2 is null) {
            return p1 is null && p2 is null;
        }
        return p1.Name == p2.Name && p1.Age == p2.Age;
    }

    public static bool operator !=(Person p1, Person p2) {
        return !(p1 == p2);
    }

    public override string ToString() {
        return $"{Name} ({Age})";
    }
}
