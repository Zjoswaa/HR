class Program {
    public static void Main() {
        PrintIsLeapYear(2024);
    }

    public static bool IsDivisibleBy(int first, int second) {
        return first % second == 0;
    }

    public static bool IsLeapYear(int year) {
        return (IsDivisibleBy(year, 4) && !IsDivisibleBy(year, 100)) || IsDivisibleBy(year, 400);
    }
    
    public static void PrintIsLeapYear(int year) {
        if (IsLeapYear(year)) {
            Console.WriteLine($"{year} is a leap year.");
            return;
        }
        Console.WriteLine($"{year} is not a leap year.");
    }
};
