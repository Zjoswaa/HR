class Program {
    public static void Main() {
        List<Customer> Customers = new() {
            new Customer() { Name = "Alice", City = "New York" },
            new Customer() { Name = "Bob", City = "London" },
            new Customer() { Name = "Charlie", City = "New York" },
            new Customer() { Name = "Dave", City = "Paris" },
        };

        var selectedCustomers =
            from customer in Customers
            where customer.City == "New York"
            select customer.Name;

        foreach (string name in selectedCustomers) {
            Console.WriteLine(name);
        }
    }
}
