class Program {
    public static void Main() {
        var company = new Company();
        var people = new List<Employee>()
        {
            new Employee(3000, 10),
            new Employee(2500, 20),
            new Employee(3500, 15),
            new Employee(3000, 20),
        };
        foreach (var person in people) {
            company.Hire(person);
        }

        company.PayMonthlySalary();
        foreach (var employee in company.Employees) {
            Console.WriteLine($"Employee has earned {employee.SalaryEarned}");
        }
    }
}
