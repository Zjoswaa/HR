class Person {
    public string Name;
    public Animal Pet;

    public Person(string name, Animal pet) {
        Name = name;
        Pet = pet;
    }

    public string Info() {
        if (Pet == null) {
            return $"{Name} has no pet";
        } 
        return $"{Name} has a pet that makes the sound {Pet.MakeSound()}";
    }
}
