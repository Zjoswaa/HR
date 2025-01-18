public class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "STR TO ENUM":
                StrToEnum();
                return;
            case "ENUM TO STR":
                EnumToStr();
                return;
            default: throw new ArgumentException();
        }
    }

    static void StrToEnum() {
        // Convert string to enum and print
        var unitStrArr = new string[] { "C", "F", "K", "X" };
        foreach (var unitStr in unitStrArr) {
            try {
                TemperatureUnit parsedUnit = TemperatureConverter.ConvertToEnum(unitStr);
                Console.WriteLine("Parsed temperature unit: " + parsedUnit);
            }
            catch (ArgumentException ex) {
                Console.WriteLine($"{ex.Message}: {unitStr}");
            }
        }
    }

    static void EnumToStr() {
        // Convert enum to string for all temperature units
        foreach (TemperatureUnit tempUnit in Enum.GetValues(typeof(TemperatureUnit))) {
            string tempUnitString = TemperatureConverter.ConvertToString(tempUnit);
            Console.WriteLine("Temperature unit: " + tempUnitString);
        }
    }
}
