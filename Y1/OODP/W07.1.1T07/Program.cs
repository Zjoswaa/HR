public class Program {
    public static void Main() {
        Pair<int, int> pair1 = new(5, 10);
        Pair<int, string> pair2 = new(5, "five");
        Pair<DateTime, DateTime> pair3 = new(
            new(2021, 11, 20, 13, 0, 0, DateTimeKind.Utc),
            new(2021, 11, 20, 14, 30, 17, DateTimeKind.Utc)
        );
        Console.WriteLine($"{pair1.Fst} {pair1.Snd}");
        Console.WriteLine($"{pair2.Fst} {pair2.Snd}");
        Console.WriteLine($"{pair3.Fst} {pair3.Snd}");

        Triple<int, char, string> triple1 = new(
            1, '1', "one");
        Triple<string, string, string> triple2 = new(
            "Huey", "Dewey", "Louie");
        Console.WriteLine($"{triple1.Fst} {triple1.Snd} {triple1.Trd}");
        Console.WriteLine($"{triple2.Fst} {triple2.Snd} {triple2.Trd}");
    }
}
