class Program {
    public static void Main() {
        int maxHP = 10;
        int currHP = 5;

        currHP = DrinkPotion(currHP, maxHP);
        DisplayStatus(currHP);

        currHP = TakeDamage(currHP, 15);
        DisplayStatus(currHP);
    }

    public static void DisplayStatus(int currHP) {
        Console.WriteLine($"Current HP: {currHP}{(currHP <= 0 ? " (Dead)" : "")}");
    }

    public static int DrinkPotion(int currHP, int maxHP) => Minimum(currHP + 10, maxHP);
    public static int TakeDamage(int currHP, int damage) => Maximum(currHP - damage, 0);

    public static int Minimum(int n1, int n2) => n1 < n2 ? n1 : n2;
    public static int Maximum(int n1, int n2) => n1 > n2 ? n1 : n2;
}
