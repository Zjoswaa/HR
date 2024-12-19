public class WeatherData {
    private readonly double[] _data;

    public int NumberOfReadings => _data.Length;

    public WeatherData(double[] data) => _data = data;

    public double GetHighestTemperature() {
        try {
            return _data.Max();
        }
        catch (InvalidOperationException) {
            return 0.0;
        }
        
    }
}
