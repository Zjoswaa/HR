using System.Collections;

class Bank : IEnumerable<Account> {
    private List<Account> _accounts = new();

    public void Add(Account Account) {
        _accounts.Add(Account);
    }

    public IEnumerator<Account> GetEnumerator() {
        return _accounts.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public void SortByAccountNumber() {
        _accounts.Sort();
    }

    public bool ContainsAccount(Account Account) {
        return _accounts.Contains(Account);
    }
}
