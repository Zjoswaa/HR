public class GasEngine : IEngine {
    public int NumCylinders { get; set; }
    public double Horsepower { get; set; }

    public GasEngine(int numCylinders, double horsepower) {
        NumCylinders = numCylinders;
        Horsepower = horsepower;
    }

    public void Start() => Console.WriteLine("Starting gas engine...");
    public void Stop() => Console.WriteLine("Stopping gas engine...");
}
