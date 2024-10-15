public class Motorcycle {
    public string Make;
    public string Model;
    public int Year;

    public Motorcycle(string make, string model, int year) {
        Make = make;
        Model = model;
        Year = year;
    }

    public virtual string Ride() => $"Riding a {Make} {Model} from {Year}";
}
