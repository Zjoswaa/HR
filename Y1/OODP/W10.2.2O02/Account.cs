class Account : IEquatable<Account>, IComparable<Account> {
    public int AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public double Balance { get; set; }

    public bool Equals(Account? Account) {
        if (Account is null) {
            return false;
        }

        return this.AccountNumber == Account.AccountNumber && this.AccountHolderName == Account.AccountHolderName && this.Balance == Account.Balance;
    }

    public override bool Equals(object? obj) {
        return obj is Account account && this.Equals(account);
    }

    public int CompareTo(Account? Account) {
        if (this.AccountNumber == Account.AccountNumber) {
            return 0;
        }
        if (this.AccountNumber < Account.AccountNumber) {
            return -1;
        }
        return 1;
    }

    public static bool operator ==(Account a1, Account a2) {
        if (a1 is null || a2 is null) {
            return a1 is null && a2 is null;
        }
        return a1.Equals(a2);
    }

    public static bool operator !=(Account a1, Account a2) {
        return !(a1 == a2);
    }
}
