public abstract class Bill {
    private double _amount;
    protected string CustomerName;

    protected Bill(double amount, string customerName) {
        _amount = amount;
        CustomerName = customerName;
    }

    public virtual double Amount { get => _amount; }
    public abstract string GetDescription();
}
