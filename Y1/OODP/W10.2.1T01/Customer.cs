public class Customer {
    public int ID { get; set; }
    private static int _number;
    public string Name { get; set; }
    public string Address { get; set; }

    public Customer(string name, string address) {
        Name = name;
        Address = address;
        ID = ++_number;
    }
}
