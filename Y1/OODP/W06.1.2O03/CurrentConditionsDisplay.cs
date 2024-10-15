class CurrentConditionsDisplay : IObserver, IDisplay {
    private IObservable _Observable { get; set; }
    private double _Temperature { get; set; }
    private double _Humidity { get; set; }

    public CurrentConditionsDisplay(IObservable Observable) {
        _Observable = Observable;
    }

    public void Update() {
        if (_Observable is WeatherData Data) {
            _Temperature = Data.Temperature;
            _Humidity = Data.Humidity;
        }
    }

    public void Display() {
        Console.WriteLine($"Current conditions: {_Temperature}C degrees and {_Humidity}% humidity");
    }
}
