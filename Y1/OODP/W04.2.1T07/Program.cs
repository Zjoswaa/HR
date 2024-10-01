class Program {
    public static void Main() {
        Person john = new("John Doe");
        Student jane = new("Jane Doe");

        Console.WriteLine(john.Introduce());
        Console.WriteLine(jane.Introduce());
        Console.WriteLine(jane.Status());

        jane.Graduate();

        Console.WriteLine(jane.Status());
    }
}
