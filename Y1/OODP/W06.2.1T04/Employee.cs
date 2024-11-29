public class Employee {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public Employee(string firstName, string lastName, string email) {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public void PrintEmployeeInfo() {
        Console.WriteLine($"Employee: {FirstName} {LastName} ({Email})");
    }
}
