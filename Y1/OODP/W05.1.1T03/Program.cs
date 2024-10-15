public class Program {
    public static void Main() {
        List<Animal> animals = new()
        {
            new Dog("Odie"),
            new Cat("Garfield"),
        };

        foreach (var animal in animals) {
            animal.Speak();
            if (animal is Dog)
                (animal as Dog).Fetch();
            else if (animal is Cat)
                (animal as Cat).Climb();
        }
    }
}
