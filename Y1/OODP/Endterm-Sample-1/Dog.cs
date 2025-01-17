public class Dog : Animal, IPet {
    public string Owner { get; }

    public Dog(string name, int age, string owner) : base(name, age) {
        Owner = owner;
    }
}
