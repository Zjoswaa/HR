class StatisticsDisplay : IObserver, IDisplay {
    private IObservable _Observable { get; set; }
    private double _MinTemperature { get; set; }
    private double _Maxtemperature { get; set; }

    public StatisticsDisplay(IObservable Observable) {
        _Observable = Observable;
        if (_Observable is WeatherData Data) {
            _MinTemperature = Data.Temperature;
            _Maxtemperature = Data.Temperature;
        }
    }

    public void Update() {
        if (_Observable is WeatherData Data) {
            if (Data.Temperature > _Maxtemperature) {
                _Maxtemperature = Data.Temperature;
            }
            if (Data.Temperature < _MinTemperature) {
                _MinTemperature = Data.Temperature;
            }
        }
    }

    public void Display() {
        Console.WriteLine($"Avg/Min/Max temperature = {(_MinTemperature + _Maxtemperature) / 2}/{_MinTemperature}/{_Maxtemperature}");
    }
}
