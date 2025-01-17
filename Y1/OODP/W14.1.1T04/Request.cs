class Request {
    public string Name { get; }
    public string Description { get; }
    public string CustomerName { get; }

    public Request(string name, string description, string customerName) {
        Name = name;
        Description = description;
        CustomerName = customerName;
    }

    public override string ToString() {
        return $"Name: {Name}\nDescription: {Description}\nCustomer Name: {CustomerName}";
    }
}
