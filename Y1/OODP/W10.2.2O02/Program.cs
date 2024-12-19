static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Sort":
                TestSort();
                return;
            case "Equal":
                TestEqual();
                return;
            case "Enumerable":
                TestEnumerable();
                return;
            default: throw new ArgumentException();
        }
    }

    public static void TestSort() {
        List<Account> accounts = new() {
            new Account { AccountNumber = 101, AccountHolderName = "John Doe", Balance = 1000 },
            new Account { AccountNumber = 102, AccountHolderName = "Jane Smith", Balance = 5000 },
            new Account { AccountNumber = 103, AccountHolderName = "Bob Johnson", Balance = 2000 },
        };

        accounts.Sort();
        foreach (var account in accounts) {
            Console.WriteLine(account.AccountNumber);
        }
    }

    public static void TestEqual() {
        Account acc1 = new Account { AccountNumber = 101, AccountHolderName = "John Doe", Balance = 1000 };
        Account acc2 = new Account { AccountNumber = 101, AccountHolderName = "John Doe", Balance = 1000 };
        Account acc3 = new Account { AccountNumber = 102, AccountHolderName = "Jane Smith", Balance = 5000 };
        Account acc4 = new Account { AccountNumber = 103, AccountHolderName = "Bob Johnson", Balance = 2000 };
        SavingsAccount acc5 = new SavingsAccount
            { AccountNumber = 101, AccountHolderName = "John Doe", Balance = 1000 };
        SavingsAccount acc6 = new SavingsAccount
            { AccountNumber = 101, AccountHolderName = "John Doe", Balance = 2000 };
        CreditCardAccount acc7 = new CreditCardAccount
            { AccountNumber = 101, AccountHolderName = "John Doe", Balance = 1000 };
        Account acc8 = null;
        Account acc9 = null;

        Console.WriteLine("Using the Equals method:");
        Console.WriteLine("acc1.Equals(acc2): " + acc1.Equals(acc2)); //true
        Console.WriteLine("acc2.Equals(acc3): " + acc2.Equals(acc3)); //false
        Console.WriteLine("acc1.Equals(acc4): " + acc1.Equals(acc4)); //false
        Console.WriteLine("acc1.Equals(acc5): " + acc1.Equals(acc5)); //true
        Console.WriteLine("acc1.Equals(acc6): " + acc1.Equals(acc6)); //false
        Console.WriteLine("acc1.Equals(acc7): " + acc1.Equals(acc7)); //false
        Console.WriteLine("acc1.Equals(acc8): " + acc1.Equals(acc8)); //false
        Console.WriteLine("((object).Equals(acc2): " + ((object)acc1).Equals(acc2)); //true

        Console.WriteLine("\nUsing overloaded operators:");
        Console.WriteLine("acc1 == acc2: " + (acc1 == acc2)); //true
        Console.WriteLine("acc2 == acc3: " + (acc2 == acc3)); //false
        Console.WriteLine("acc4 != acc5: " + (acc4 != acc5)); //true
        Console.WriteLine("acc4 != acc6: " + (acc4 != acc6)); //true
        Console.WriteLine("acc4 == null: " + (acc4 == null)); //false
        Console.WriteLine("null == acc5: " + (null == acc5)); //false
        Console.WriteLine("acc8 == acc9: " + (acc8 == acc9)); //true
    }

    public static void TestEnumerable() {
        Account acc1 = new Account { AccountNumber = 101, AccountHolderName = "John Doe", Balance = 1000 };
        Account acc2 = new Account { AccountNumber = 102, AccountHolderName = "Jane Smith", Balance = 5000 };
        Account acc3 = new Account { AccountNumber = 103, AccountHolderName = "Bob Johnson", Balance = 2000 };

        Bank bank = new() {
            acc3,
            acc1,
            acc2
        };

        bank.SortByAccountNumber();
        foreach (Account a in bank) {
            Console.WriteLine($"Account Number: {a.AccountNumber}, "
                              + $"Account Holder: {a.AccountHolderName}, "
                              + $"Balance: ${a.Balance}");
        }
    }
}