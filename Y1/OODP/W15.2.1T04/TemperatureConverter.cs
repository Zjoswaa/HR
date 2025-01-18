public enum TemperatureUnit {
    Celsius,
    Fahrenheit,
    Kelvin
}

static class TemperatureConverter {
    public static string? ConvertToString(TemperatureUnit unit) {
        switch (unit) {
            case TemperatureUnit.Celsius:
                return "C";
            case TemperatureUnit.Fahrenheit:
                return "F";
            case TemperatureUnit.Kelvin:
                return "K";
        }
        return null;
    }

    public static TemperatureUnit ConvertToEnum(string input) {
        switch (input) {
            case "C":
                return TemperatureUnit.Celsius;
            case "F":
                return TemperatureUnit.Fahrenheit;
            case "K":
                return TemperatureUnit.Kelvin;
            default:
                throw new ArgumentException("Invalid temperature unit string");
        }
    }
}
