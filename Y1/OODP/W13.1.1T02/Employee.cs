public class Employee {
    public string Name { get; set; }
    public int Salary { get; set; }

    public Employee(string name, int salary) {
        Name = name;
        Salary = salary;
    }

    // UpdateEmployee goes here
    public void UpdateEmployee(Action<Employee> action) {
        action(this);
    }

    public override string ToString() => $"{Name} ({Salary})";
}
