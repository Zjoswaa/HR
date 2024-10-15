static class Program {
    static void Main() {
        List<Employee> employees = new()
        {
            new Employee("Michael Gary Scott", 6000),
            new Employee("James Halpert", 4000),
        };

        List<Consultant> consultants = new()
        {
            new Consultant("Peter Drucker", 200),
            new Consultant("Simon Sinek", 250),
        };
        foreach (var consultant in consultants) {
            consultant.HoursWorked = 30;
        }

        List<IPayable> payables = new();
        payables.AddRange(employees);
        payables.AddRange(consultants);

        foreach (var payable in payables) {
            Console.WriteLine(payable.Info);
            Console.WriteLine(payable.GetPaymentAmount());
        }
    }
}
