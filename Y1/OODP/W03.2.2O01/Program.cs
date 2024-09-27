using System;

class Program {
    public static void Main() {
        TestIndexToDay();

        TestDayOfWeekInstance(10);
        TestDayOfWeekInstance(-1);
    }

    private static void TestIndexToDay() {
        Console.WriteLine("Testing IndexToDay");
        for (int i = -7; i < 7; i++) {
            Console.WriteLine($"Index: {i}; Day: {DayOfWeek.IndexToDay(i)}");
        }
        Console.WriteLine();
    }

    private static void TestDayOfWeekInstance(int startIndex) {
        Console.WriteLine($"Testing class object with index {startIndex}");
        DayOfWeek dayOfWeek = new(startIndex);
        List<string> days = new();
        for (int i = -7; i < 7; i++) {
            days.Add(dayOfWeek.IsWeekend()
                ? dayOfWeek.CurrentDay() + " :)"
                : dayOfWeek.CurrentDay());
            dayOfWeek.NextDay();
        }

        foreach (var day in days)
            Console.WriteLine(day);
    }
}
