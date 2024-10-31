class Teacher : Person {
    public override string FirstName { get; set; }
    public override string LastName { get; set; }
    public string Course { get; set; }

    public Teacher(string firstName, string lastName, int age, string course)
        : base(firstName, lastName, age) => Course = course;

    public override string Greet() => "Good morning, students!";
    public override string GetFullName() => $"{FirstName} {LastName}";
}
