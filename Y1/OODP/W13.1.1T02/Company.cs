public class Company {
    private List<Employee> _employees { get; } = new();
    public void HireEmployee(Employee emp) => _employees.Add(emp);

    // FilterEmployees goes here
    public List<Employee> FilterEmployees(Func<Employee, bool> func) {
        return _employees.Where(func).ToList();
    }
}
