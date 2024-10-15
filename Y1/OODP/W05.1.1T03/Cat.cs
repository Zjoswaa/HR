class Cat : Animal {
    public Cat(string Name) : base(Name) {
        this.Sound = "Meow!";
    }

    public void Climb() {
        Console.WriteLine($"{this.Name} climbs the curtains");
    }
}
