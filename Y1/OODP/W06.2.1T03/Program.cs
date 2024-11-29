class Program {
    public static void Main() {
        List<Bill> Bills = new() {
            new ElectricityBill(50, "John Smith"),
            new ElectricityBill(75, "Jane Doe"),
            new GasBill(100, "Bob Johnson", false),
            new GasBill(125, "John Doe", true)
        };

        double Total = 0;
        foreach (Bill Bill in Bills) {
            Console.WriteLine(Bill.GetDescription());
            Total += Bill.Amount;
        }
        Console.WriteLine($"Total amount: {(int)Total}");
    }
}
