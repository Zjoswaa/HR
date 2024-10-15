public class ElectricEngine : IEngine {
    public double Horsepower { get; set; }
    public ElectricEngine(double horsepower) => Horsepower = horsepower;

    public void Start() => Console.WriteLine("Starting electric engine...");
    public void Stop() => Console.WriteLine("Stopping electric engine...");
}
