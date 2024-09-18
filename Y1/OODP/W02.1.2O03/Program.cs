public class Program {
    public static void Main() {
        Player p1 = new Player("John Snow", 30);
        Player p2 = new Player("Night King", 60);
        Player winner = null;
        Console.WriteLine($"{p1.Name}: {p1.Power} Power; {p1.HealthPoints} Healthpoints");
        Console.WriteLine($"{p2.Name}: {p2.Power} Power; {p2.HealthPoints} Healthpoints");
        while (winner == null)
        {
            p1.TakeDamage(p2.Power);
            p2.TakeDamage(p1.Power);
            if (!p1.IsAlive())
                winner = p2;
            else if (!p2.IsAlive())
                winner = p1;
            Console.WriteLine($"{p1.Name}: {p1.Power} Power; {p1.HealthPoints} Healthpoints");
            Console.WriteLine($"{p2.Name}: {p2.Power} Power; {p2.HealthPoints} Healthpoints");
        }

        Console.WriteLine($"-----The winner is:-----\n{winner.Name}: {winner.Power} Power; {winner.HealthPoints} Healthpoints");
    }
}
