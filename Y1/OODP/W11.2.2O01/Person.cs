class Person : IComparable<Person> {
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string Name, int Age) {
        this.Name = Name;
        this.Age = Age;
    }

    public int CompareTo(Person? other) {
        if (other is null) {
            return 1;
        }
        if (this.Age < other.Age) {
            return -1;
        }
        if (this.Age == other.Age) {
            return 0;
        }
        return 1;
    }

    public override string ToString() {
        return $"{Name}, {Age} years old";
    }
}
