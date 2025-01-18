public class Program {
    static void Main() {
        Calendar calendar = new(Month.May);
        calendar.DisplayCurrentMonth();

        for (int i = 0; i < 12; i++) {
            calendar.SetNextMonth();
            calendar.DisplayCurrentMonth();
        }
    }
}
