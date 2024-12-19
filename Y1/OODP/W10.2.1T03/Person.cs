class Person : IEquatable<Person> {
    public string Name { get; set; }
    public int Age { get; set; }

    public bool Equals(Person? other) {
        if (other == null) {
            return false;
        }

        return this.Name == other.Name && this.Age == other.Age;
    }

    public override string ToString() {
        return $"{Name} ({Age})";
    }
}
