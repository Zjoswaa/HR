class Program {
    public static void Main() {
        Person john = new("John Doe");
        Student jane = new("Jane Doe");
        List<Person> People = new() { john, jane };
        
        foreach (Person person in People) {
            Console.WriteLine(person.Introduce());
            if (person is Student student) {
                Console.WriteLine(student.Status());
            }
        }
    }
}
