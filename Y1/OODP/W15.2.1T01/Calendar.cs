public enum Month // Change the numbering, so that it starts at 1
{
    January = 1,
    February = 2,
    March = 3,
    April = 4,
    May = 5,
    June = 6,
    July = 7,
    August = 8,
    September = 9,
    October = 10,
    November = 11,
    December = 12
}

public class Calendar {
    private Month _currentMonth;

    public Calendar(Month initialMonth) {
        _currentMonth = initialMonth;
    }

    public void DisplayCurrentMonth() {
        Console.WriteLine($"Current month: {_currentMonth} ({(int)_currentMonth})"); // Add the month number
    }

    public void SetNextMonth() {
        if (_currentMonth == Month.December) {
            _currentMonth = Month.January;
            return;
        }
        _currentMonth++;
    }
}
