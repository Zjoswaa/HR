public class SalesPerson : Employee {
    public int SalesTarget { get; set; }

    public SalesPerson(string firstName, string lastName, string email, int salesTarget)
        : base(firstName, lastName, email) {
        SalesTarget = salesTarget;
    }

    public new void PrintEmployeeInfo() {
        Console.WriteLine($"Sales Person: {FirstName} {LastName} ({Email}), Sales Target: {SalesTarget}");
    }
}
