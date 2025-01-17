public class Program {
    static void Main() {
        // Create a new company and hire employees
        Company company = new();
        List<Employee> employees = new() {
            new Employee("John", 3000),
            new Employee("Jane", 3000),
            new Employee("John", 3500),
            new Employee("Jack", 3500),
            new Employee("Jill", 4000),
            new Employee("John", 4000),
        };
        foreach (Employee emp in employees) {
            company.HireEmployee(emp);
        }

        // Filter employees by name
        List<Employee> filteredByName = company.FilterEmployees(emp => emp.Name == "John");
        Console.WriteLine("All employees named John:");
        foreach (Employee emp in filteredByName) {
            Console.WriteLine(" - " + emp);
        }

        // Filter employees by salary
        List<Employee> filteredBySalary =
            company.FilterEmployees(emp => emp.Salary >= 3500);
        Console.WriteLine("All employees earning at least 3500:");
        foreach (Employee emp in filteredBySalary) {
            Console.WriteLine(" - " + emp);
        }

        // Increase all employee salaries
        foreach (Employee emp in employees) {
            emp.UpdateEmployee(e => e.Salary += 100);
        }
        Console.WriteLine("Updated salaries:");
        foreach (Employee emp in employees) {
            Console.WriteLine(" - " + emp);
        }
    }
}
