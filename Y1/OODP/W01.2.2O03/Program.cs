using System;

class Program {
    public static void Main() {
        Fighter you = new Fighter();
        Fighter enemy = new Fighter();
        int turnsTaken = 0;

        for (int i = 0; i < 3; i++) {
            turnsTaken++;
            enemy.Health -= you.Attack();
        }

        Console.WriteLine($"The enemy's HP was reduced to {enemy.Health}");
        Console.WriteLine($"It took you {turnsTaken} to defeat the enemy");
    }
}
