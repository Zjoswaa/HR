class Car : IEquatable<Car> {
    public string Make { get; }
    public string Model { get; }
    public Tire[] Tires { get; } = [];
    
    public Car(string make, string model, string tireBrand) {
        Make = make;
        Model = model;
        for (int i = 0; i < 4; i++) {
            Tires.Append(new Tire(tireBrand));
        }
    }

    public bool TryDrive() {
        foreach (Tire tire in Tires) {
            if (tire.Durability < 1) {
                return false;
            }
        }
        foreach (Tire tire in Tires) {
            tire.Use();
        }
        return true;
    }

    public void ReplaceTire(Tire tire, int index) {
        Tires[index] = tire;
    }

    public void ReplaceTire(string tireBrand, int index) {
        Tires[index] = new Tire(tireBrand);
    }

    public string GetTireInfo() {
        return $"Tire 1: {Tires[0]}\nTire 2: {Tires[1]}\nTire 3: {Tires[2]}\nTire 4: {Tires[3]}";
    }

    public bool Equals(Car? other) {
        if (other is null) {
            return false;
        }
        return this.Make == other.Make && this.Model == other.Model;
    }

    public override bool Equals(object? other) {
        if (!(other is Car car)) {
            return false;
        }
        return this.Equals(car);
    }

    public static bool operator ==(Car? c1, Car? c2) {
        if (c1 is null || c2 is null) {
            return c1 is null && c2 is null;
        }
        return c1.Equals(c2);
    }

    public static bool operator !=(Car c1, Car c2) {
        return !(c1 == c2);
    }
}
