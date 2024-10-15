class Program {
    public static void Main() {
        var account1 = new BankAccount(1000, 0.05);
        var account2 = new SavingsAccount(2500, 0.04);
        var withdrawn = 0.0;
        for (int year = 0; year <= 6; year++) {
            foreach (var account in new BankAccount[] { account1, account2 }) {
                account.NextYear();
                if (year > 0 && year % 3 == 0) {
                    withdrawn += account.Withdraw(500);
                }
            }
        }

        Console.WriteLine($"Balance account1: {Math.Round(account1.ReadBalance(), 2)}");
        Console.WriteLine($"Balance account2: {Math.Round(account2.ReadBalance(), 2)}");
        Console.WriteLine($"Total withdrawn: {withdrawn}");
    }
}
