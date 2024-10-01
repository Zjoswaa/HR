class Employee : Person {
    public double Salary;

    public Employee(string Name, double Salary) : base(Name) {
        this.Salary = Salary;
    }
}
