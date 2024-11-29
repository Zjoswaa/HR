public class Program {

    public static void Main() {
        List<string> rewardItems = new() { "Potion", "Sword" };
        List<int> rewardGold = new() { 1, 5, 10, 50, 100 };

        for (int i = 0; i < 25; i++) {
            Console.WriteLine(RewardGenerator.GetRandomElement(rewardItems));
            Console.WriteLine(RewardGenerator.GetRandomElement(rewardGold));
        }
    }
}
