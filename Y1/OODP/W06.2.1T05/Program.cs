class Program {
    public static void Main() {
        Employee John = new("John", "Doe", "john.doe@example.com");
        Manager Jane = new("Jane", "Doe", "jane.doe@example.com", "Sales");
        SalesPerson Bob = new("Bob", "Smith", "bob.smith@example.com", 100_000);

        (John as Employee).PrintEmployeeInfo();
        (Jane as Employee).PrintEmployeeInfo();
        (Bob as Employee).PrintEmployeeInfo();

        John.PrintEmployeeInfo();
        Jane.PrintEmployeeInfo();
        Bob.PrintEmployeeInfo();
    }
}
