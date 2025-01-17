public class Cat : Animal, IPet {
    public string Owner { get; }

    public Cat(string name, int age, string owner) : base(name, age) {
        Owner = owner;
    }
}
