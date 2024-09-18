class Program {
    public static void Main() {
        Animal pet = null;
        Person person1 = new Person("John Doe", pet);
        Console.WriteLine(person1.Info());

        pet = new Animal("Max", "Whoof!");
        Person person2 = new Person("Jane Doe", pet);
        Console.WriteLine(person2.Info());
    }
}
