class SavingsAccount : BankAccount {
    private bool _locked = true;

    public SavingsAccount(double Balance, double InterestRate) : base(Balance, InterestRate) { }

    public override double Withdraw(double Amount) {
        if (_locked) {
            return 0;
        }
        return base.Withdraw(Amount);
    }

    public override void NextYear() {
        if (this.YearsPassed < 5) {
            YearsPassed++;
            ApplyInterest();
            return;
        }
        this._locked = false;
    }
}
