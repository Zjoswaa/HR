class Program() {
    public static void Main() {
        BankAccount.InterestRatePercentage = 10;
        var account1 = new BankAccount();

        account1.Deposit(1000);
        account1.ApplyInterest();

        var account2 = new BankAccount();
        account2.Deposit(2000);

        BankAccount.InterestRatePercentage = 5;
        account1.ApplyInterest();
        account2.ApplyInterest();

        Console.WriteLine(account1.Balance);
        Console.WriteLine(account2.Balance);
    }
}
