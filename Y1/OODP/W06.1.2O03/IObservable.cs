interface IObservable {
    void RegisterObserver(IObserver Observer);
    void RemoveObserver(IObserver Observer);
    void NotifyObservers();
}
