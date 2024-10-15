public class Pedestrian : Person, ICommute {
    public Pedestrian(string name) : base(name) { }

    public void Move(int distance) {
        Console.WriteLine($"Walked {distance} kms");
    }
}
