class WeatherData : IObservable {
    private List<IObserver> _Observers { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double Pressure { get; set; }

    public void RegisterObserver(IObserver Observer) {
        _Observers.Add(Observer);
    }

    public void RemoveObserver(IObserver Observer) {
        _Observers.Remove(Observer);
    }

    public void NotifyObservers() {
        foreach (IObserver Observer in _Observers) {
            Observer.Update();
        }
    }

    public void SetMeasurements(double Temperature, double Humidity, double Pressure) {
        this.Temperature = Temperature;
        this.Humidity = Humidity;
        this.Pressure = Pressure;
        MeasurementsChanged();
    }

    public void MeasurementsChanged() {
        NotifyObservers();
    }
}
