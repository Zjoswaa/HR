public class ElectricityBill : Bill {
    public ElectricityBill(double amount, string customerName)
        : base(amount, customerName) { }

    public override string GetDescription() {
        return $"Electricity bill for customer {CustomerName}: {(int)Amount}";
    }
}
