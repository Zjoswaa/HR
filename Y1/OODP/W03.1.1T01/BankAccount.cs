class BankAccount {
    public static double InterestRatePercentage = 0.0;
    public double Balance = 0.0;

    public void Deposit(double Amount) {
        this.Balance += Amount;
    }

    public void ApplyInterest() {
        this.Balance *= (1 + (InterestRatePercentage / 100));
    }
}
