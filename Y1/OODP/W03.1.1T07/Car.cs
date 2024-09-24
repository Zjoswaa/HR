class Car {
    public const int NumberOfWheels = 4;
    public int Mileage = 0;

    public Car() => Mileage = 0;

    public void Drive() => Mileage++;
}
