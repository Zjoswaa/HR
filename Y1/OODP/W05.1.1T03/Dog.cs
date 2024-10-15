class Dog : Animal {
    public Dog(string Name) : base(Name) {
        this.Sound = "Woof!";
    }

    public void Fetch() {
        Console.WriteLine($"{this.Name} fetches the stick");
    }
}
