public enum DayOfWeek {
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public static class DayOfWeekChecker {
    public static void CheckDayOfWeek(string input) {
        if (!Enum.TryParse(input, out DayOfWeek day)) {
            Console.WriteLine("Invalid input.");
            return;
        }

        // Create a switch here that, depending on the user input, prints:
        //  - It's a weekday.
        //  - It's the weekend.
        //  - Invalid day of the week
        Console.WriteLine(
            day switch {
                >= DayOfWeek.Monday and <= DayOfWeek.Friday => "It's a weekday.",
                DayOfWeek.Saturday or DayOfWeek.Sunday => "It's the weekend.",
                _ => "Invalid day of the week"
            });
    }
}
