public static class ColorChecker {
    public static bool HasMatch(List<string> colors, Func<string, bool> predicate) {
        if (colors.Count == 0) {
            return false;
        }

        // If last item in the list matches
        if (predicate(colors[^1])) {
            return true;
        }

        // Remove last item
        colors.RemoveAt(colors.Count - 1);
        return HasMatch(colors, predicate);
    }

    public static void ColorExists(string color, List<string> colors) {
        bool result = HasMatch(colors, c => c == color);
        Console.WriteLine($"Color '{color}' exists: {result}");
    }

    public static void ColorStartingWith(string letter, List<string> colors) {
        bool result = HasMatch(colors, c => c.StartsWith(letter));
        Console.WriteLine($"Color that starts with letter '{letter}' exists: {result}");
    }
}
