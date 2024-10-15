class Person {
    private string _firstName;
    private string _lastName;
    public string FullName {
        get {
            return $"{_firstName} {_lastName}";
        }
    }

    public Person(string FirstName, string LastName) {
        _firstName = FirstName;
        _lastName = LastName;
    }


}
