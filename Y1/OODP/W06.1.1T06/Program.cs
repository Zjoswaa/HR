public class Program {
    public static void Main() {
        Vehicle car = new Vehicle("Honda", "Accord", new GasEngine(4, 185));
        Vehicle scooter = new Vehicle("Vespa", "LX150", new ElectricEngine(4.4));

        foreach (var vehicle in new List<Vehicle>() { car, scooter }) {
            Console.WriteLine($"Vehicle's horsepower: {vehicle.Engine.Horsepower}");
            IEngine engine = vehicle.Engine;
            engine.Start();
            engine.Stop();
        }
    }
}
