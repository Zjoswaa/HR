class Program {
    static void Main() {
        Person person1 = new Person("Bruce", "Wayne");
        Person person2 = new Person("Clark", "Kent");
        Person person3 = new Person("Diana", "Prince");

        var personList = new List<Person>() { person1, person2, person3 };
        foreach (var person in personList)
            Console.WriteLine(person.Introduce());
    }
}
