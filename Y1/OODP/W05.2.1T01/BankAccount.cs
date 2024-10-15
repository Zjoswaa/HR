class BankAccount {
    private double _balance;
    protected int YearsPassed = 0;
    protected double InterestRate;

    public BankAccount(double Balance, double InterestRate) {
        _balance = Balance;
        this.InterestRate = InterestRate;
    }

    public double ReadBalance() {
        return _balance;
    }

    public void Deposit(double Amount) {
        _balance += Math.Max(0, Amount);
    }

    public virtual double Withdraw(double Amount) {
        if (!SufficientBalance(Amount)) {
            return 0;
        }
        _balance -= Math.Max(0, Amount);
        return Math.Max(0, Amount);
    }

    public virtual void NextYear() {
        ApplyInterest();
    }

    protected virtual void ApplyInterest() {
        _balance += _balance * this.InterestRate;
    }

    private bool SufficientBalance(double Amount) {
        return _balance >= Amount;
    }
}
