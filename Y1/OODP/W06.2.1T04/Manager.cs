public class Manager : Employee {
    public string Department { get; set; }

    public Manager(string firstName, string lastName, string email, string department)
        : base(firstName, lastName, email) {
        Department = department;
    }

    public new void PrintEmployeeInfo() {
        Console.WriteLine($"Manager: {FirstName} {LastName} ({Email}), Department: {Department}");
    }
}
