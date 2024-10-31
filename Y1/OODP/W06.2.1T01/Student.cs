class Student : Person {
    public override string FirstName { get; set; }
    public override string LastName { get; set; }
    public bool HasGraduated { get; set; }

    public Student(string firstName, string lastName, int age)
        : base(firstName, lastName, age) { }

    public override string Greet() => "Good morning, teacher!";
    public override string GetFullName() {
        return $"{(HasGraduated ? "BSc " : "")}{base.GetFullName()}";
    }
}
