class Program {
    public static void Main() {
        Person John = new Person("John", new List<Pet> { new Pet("Dog", "Nugent"), new Pet("Cat", "Steve"), new Pet("Goldfish", "Brutus") });

        foreach (Pet pet in John.Pets) {
            Console.WriteLine($"{John.Name} has a {pet.WhatAmI} named {pet.Name}");
        }
    }
}
