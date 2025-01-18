public class Program {
    static void Main() {
        Console.WriteLine("Enter a day of the week:");
        string input = Console.ReadLine();
        DayOfWeekChecker.CheckDayOfWeek(input);
    }
}
