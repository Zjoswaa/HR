class Bird : Animal {
    public int FlightDistanceInKM { get; }

    public Bird(string Species, int Age, int FlightDistanceInKM) : base(Species, Age) {
        this.FlightDistanceInKM = FlightDistanceInKM;
    }
}
