class LimitedEditionCar {
    const string Model = "Porsche 918 Spyder";
    public static int Counter = 0;
    public readonly string ChassisNumber;

    public LimitedEditionCar() {
        Counter++;
        this.ChassisNumber = $"CHNO{Counter}";
    }
}
