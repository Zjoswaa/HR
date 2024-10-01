class Student : Person {
    public bool IsGraduated;
    public Student(string name) : base(name) => IsGraduated = false;

    public void Graduate() => IsGraduated = true;

    public string Status() {
        if (IsGraduated)
            return "I have graduated!";
        else
            return "I have yet to graduate.";
    }
}
