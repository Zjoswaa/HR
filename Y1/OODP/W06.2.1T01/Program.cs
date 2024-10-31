public class Program {
    public static void Main() {
        List<Person> people = new()
        {
            new Student("John", "Doe", 18),
            new Student("Jane", "Doe", 17),
            new Teacher("Jack", "Doe", 30, "OODP"),
            new Teacher("Jill", "Doe", 34, "Project"),
        };

        foreach (Person person in people) {
            Console.WriteLine(person.GetFullName());
            Console.WriteLine(person.Age);
            Console.WriteLine(person.Greet());
            if (person is Teacher)
                Console.WriteLine((person as Teacher).Course);
        }
    }
}
