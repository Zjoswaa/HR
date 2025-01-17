class Car : IEquatable<Car> {
    public string Make { get; }
    public string Model { get; }
    public Tire[] Tires { get; } = [];
    
    public Car(string make, string model, string tireBrand) {
        Make = make;
        Model = model;
        Tires = [new Tire(tireBrand), new Tire(tireBrand), new Tire(tireBrand), new Tire(tireBrand)];
    }

    public bool TryDrive() {
        for (int i = 0; i < Tires.Length; i++) {
            if (Tires[i].Durability < 1) {
                return false;
            }
        }

        for (int i = 0; i < Tires.Length; i++) {
            
            Tires[i].Use();
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
        return $"Tire 1: {Tires[0]}\nTire 2: {Tires[1]}\nTire 3: {Tires[2]}\nTire 4: {Tires[3]}\n";
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
