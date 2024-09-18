class Program {
    public static void Main() {
        List<Pet> Pets = new() {
            new Pet("Dog", "Nugent"),
            new Pet("Cat", "Steve"),
            new Pet("Goldfish", "Brutus")
        };

        foreach (Pet pet in Pets) {
            Console.WriteLine($"I have a {pet.WhatAmI} named {pet.Name}");
        }
    }
}
