public class Animal {
    public string Name;
    public string Sound;

    public Animal(string name) => Name = name;

    public void Speak() => Console.WriteLine($"{Name} says {Sound}");
}
