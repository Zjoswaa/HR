public class Program {
    public static void Main() {
        Employee luke = new("Luke", 3200);
        Employee anakin = new("Anakin", 3000);
        Manager vader = new(anakin);
        vader.TeamSize = 10;

        foreach (Employee e in new List<Employee>() { luke, anakin, vader }) {
            Console.WriteLine(e.Info);
        }
    }
}
