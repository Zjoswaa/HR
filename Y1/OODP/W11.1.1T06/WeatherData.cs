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

    public void Sort(bool ascending) {
        Array.Sort(_data);
        if (!ascending) {
            Array.Reverse(_data);
        }
    }

    public void PrintTemperatures() {
        foreach (double temp in _data) {
            Console.WriteLine(temp);
        }
    }
}
