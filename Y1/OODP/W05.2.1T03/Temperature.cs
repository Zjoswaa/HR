class Temperature {
    private double _celsius; // Backing field
    public double Celsius {
        get {
            return _celsius;
        }
        set {
            if (value >= -273.15) {
                _celsius = value;
            }
        }
    }
    public double Kelvin {
        get {
            return Celsius + 273.15;
        }
        set {
            Celsius = value - 273.15;
        }
    }
}
