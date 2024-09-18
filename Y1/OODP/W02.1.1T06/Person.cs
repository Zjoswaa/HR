class Person {
    public string FirstName;
    public string LastName;

    public Person(string FirstName, string LastName) {
        this.FirstName = FirstName;
        this.LastName = LastName;
    }

    public string Introduce() => $"I am {FirstName} {LastName}";
}
