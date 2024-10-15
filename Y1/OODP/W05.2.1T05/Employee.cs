public class Employee {
    public Employee(string name, double salary) {
        Name = name;
        Salary = salary;
    }

    public string Name { get; set; }

    private double _salary;
    public double Salary {
        get => _salary;
        set {
            if (value >= 0) {
                _salary = value;
            } else {
                throw new ArgumentException("Salary must be non-negative.");
            }
        }
    }

    public virtual string Info {
        get {
            return $"Name: {Name}; Salary: {Salary}";
        }
    }
}
