class BankAccount {
    private double _balance;

    public BankAccount(double Balance) {
        _balance = Balance;
    }

    public double ReadBalance() {
        return _balance;
    }

    public void Deposit(double Amount) {
        _balance += Math.Max(0, Amount);
    }

    public double Withdraw(double Amount) {
        if (!SufficientBalance(Amount)) {
            return 0;
        }
        _balance -= Math.Max(0, Amount);
        return Math.Max(0, Amount);
    }

    private bool SufficientBalance(double Amount) {
        return _balance >= Amount;
    }
}
