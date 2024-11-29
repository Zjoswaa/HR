public class GasBill : Bill {
    public GasBill(double amount, string customerName, bool hasLoyaltyProgram)
        : base(amount, customerName) => HasLoyaltyProgram = hasLoyaltyProgram;

    public bool HasLoyaltyProgram { get; }

    public override double Amount {
        get => HasLoyaltyProgram ? base.Amount * 0.95 : base.Amount;
    }

    public override string GetDescription() {
        return $"Gas bill for customer {CustomerName}: {(int)Amount}";
    }
}
