public class Program {
    public static void Main() {
        People people = new();
        people.Add(new Person { Name = "Alice", Age = 25 });
        people.Add(new Person { Name = "Bob", Age = 30 });
        people.Add(new Person { Name = "Charlie", Age = 35 });

        foreach (Person person in people) {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}
