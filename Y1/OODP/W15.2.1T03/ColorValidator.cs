// Create the public enum Color
// with Red, Green and Blue here

public enum Color {
    Red,
    Green,
    Blue
}

public static class ColorValidator {
    public static void DisplayColors() {
        // Print all the colors here.
        // Make sure of Enum.GetValues() with typeof(Color)
        // to get an array with all the colors.
        foreach (var item in Enum.GetValues(typeof(Color))) {
            Console.WriteLine(item);
        }
    }

    public static bool ValidateColor(string input) {
        // Print "Valid color: " plus the color and return true, if it is valid
        // Print "Invalid color" and return false otherwise.
        if (!Enum.TryParse(input, out Color color)) {
            Console.WriteLine("Invalid color");
            return false;
        }
        Console.WriteLine($"Valid color: {color}");
        return true;
    }
}
