abstract class Person {
    public abstract string FirstName { get; set; }
    public abstract string LastName { get; set; }
    public int Age { get; set; }

    public Person(string FirstName, string LastName, int Age) {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Age = Age;
    }

    public abstract string Greet();
    public virtual string GetFullName() {
        return $"{FirstName} {LastName}";
    }
}
