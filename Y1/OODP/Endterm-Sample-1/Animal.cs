public class Animal : IEquatable<Animal> {
    public string Name { get; }
    public int Age { get; }

    public Animal(string name, int age) {
        Name = name;
        Age = age;
    }

    // Implement IEquatable<Animal>,Equals(object),==,!=
    public bool Equals(Animal? other) {
        if (other is null) {
            return false;
        }
        return this.Name == other.Name && this.Age == other.Age;
    }

    public bool Equals(object? obj) {
        if (obj is null || !(obj is Animal)) {
            return false;
        }
        return this.Equals(obj as Animal);
    }

    public static bool operator ==(Animal a1, Animal a2) {
        if (a1 is null || a2 is null) {
            return a1 is null && a2 is null;
        }
        return a1.Equals(a2);
    }

    public static bool operator !=(Animal a1, Animal a2) {
        return !(a1 == a2);
    }
}
