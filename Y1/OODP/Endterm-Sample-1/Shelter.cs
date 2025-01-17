public static class Shelter {
    public static List<Animal> Animals { get; set; } = new();

    // Add and Search
    public static void AddAnimal<T>(T Animal) where T : Animal, IPet {
        Animals.Add(Animal);
    }

    public static T SearchAnimal<T>(T Animal) where T : Animal, IPet {
        foreach (Animal animal in Animals) {
            if (Animal is T && Animal == animal) {
                return (animal as T);
            }
        }
        return default;
    }
}
