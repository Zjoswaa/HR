class Car : IEquatable<Car> {
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public bool Equals(Car? other) {
        if (other is null)
            return false;

        return this.Make == other.Make &&
               this.Model == other.Model &&
               this.Year == other.Year;
    }

    public override bool Equals(object? obj) {
        if (obj is null) {
            return false;
        }
        if (obj is Car otherCar) {
            return Equals(otherCar);
        }
        return false;
    }

    public static bool operator ==(Car car1, Car car2) {
        if (car1 is null)
            return car2 is null;

        return car1.Equals(car2);
    }

    public static bool operator !=(Car car1, Car car2) {
        return !(car1 == car2);
    }
}
