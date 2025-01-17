static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "1":
                Case1();
                return;
            case "2":
                Case2();
                return;
            case "3":
                Case3();
                return;
            default: throw new ArgumentException();
        }
    }

    static void Case1() {
        int[] ints = { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };
        Func<int, bool> isEven = n => n % 2 == 0;

        int[] filtered = HOF.Filter(ints, isEven);
        foreach (int i in filtered) {
            Console.WriteLine(i);
        }
    }

    static void Case2() {
        double[] doubles = { 5.3, -6.0, 1.0, 5.1, 9.5, 7.1, 7.9, 0.1, -4.2, 7.0 };
        Func<double, bool> lessOrEqualTo2 = n => n <= 2;

        double[] filtered = HOF.Filter(doubles, lessOrEqualTo2);
        foreach (double d in filtered) {
            Console.WriteLine(d);
        }
    }

    static void Case3() {
        string[] characters = {
            "Paul Atreides", "Lady Jessica", "Duke Leto Atreides",
            "Baron Vladimir Harkonnen", "Chani", "Stilgar",
            "Irulan Corrino", "Shaddam Corrino IV",
        };
        Func<string, bool> hasMultipleNames = name => name.Split(' ').Length >= 2;

        string[] filtered = HOF.Filter(characters, hasMultipleNames);
        foreach (string character in filtered) {
            Console.WriteLine(character);
        }
    }
}
