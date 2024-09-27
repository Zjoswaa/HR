using System.Numerics;
using System.Reflection;
using System.Threading;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Mods": TestFieldModifiers(); return;
            case "Fight": TestFighting(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestFieldModifiers() {
        // Class Monster
        Type type = typeof(Monster);
        FieldInfo field = type.GetField("Name");
        Console.WriteLine("Monster's field Name is read-only: " +
            field.IsInitOnly);

        // Class Player
        type = typeof(Player);
        field = type.GetField("Name");
        Console.WriteLine("Player's field Name is constant: " +
            field.IsLiteral);

        field = type.GetField("Experience");
        Console.WriteLine("Player's field Experience is static: " +
            field.IsStatic);
    }

    public static void TestFighting() {
        Player simon = World.SpawnPlayer();
        PrintPlayerStats(simon);

        Console.WriteLine("Battle 1");
        Monster bat1 = World.SpawnBat();
        PrintMonsterStats(bat1);
        Monster bat2 = World.SpawnBat();
        PrintMonsterStats(bat2);

        simon.Attack(bat1);
        bat2.Attack(simon);
        simon.Attack(bat2);
        PrintPlayerStats(simon);
        PrintMonsterStats(bat1);
        PrintMonsterStats(bat2);

        Console.WriteLine("\nTrap");
        simon.TakeDamage(10);
        PrintPlayerStats(simon);

        Console.WriteLine("\nBattle 2");
        Monster skeleton = World.SpawnSkeleton();
        Monster zombie = World.SpawnZombie();
        simon.Attack(skeleton);
        zombie.Attack(simon);
        simon.Attack(zombie);
        PrintPlayerStats(simon);
        PrintMonsterStats(skeleton);
        PrintMonsterStats(zombie);

        Console.WriteLine("\nBattle 3");
        Monster vampire = World.SpawnVampire();
        while (simon.IsAlive() && vampire.IsAlive()) {
            simon.Attack(vampire);
            vampire.Attack(simon);
        }
        PrintPlayerStats(simon);
        PrintMonsterStats(vampire);

        Console.WriteLine("\nBattle 3 - Chance 2");
        simon = World.SpawnPlayer();
        vampire = World.SpawnVampire();
        while (simon.IsAlive() && vampire.IsAlive()) {
            simon.Attack(vampire);
            vampire.Attack(simon);
        }
        PrintPlayerStats(simon);
        PrintMonsterStats(vampire);
    }

    private static void PrintPlayerStats(Player player) {
        Console.WriteLine($"{Player.Name} [{player.GetLevel()}]");
        if (!player.IsAlive()) {
            Console.WriteLine("Dead");
            return;
        }
        Console.WriteLine($"EXP: {Player.Experience}");
        Console.WriteLine($"HP: {player.CurrentHP}/{player.MaxHP}");
        Console.WriteLine($"Strength: {player.Strength}");
    }

    private static void PrintMonsterStats(Monster monster) {
        Console.WriteLine($"{monster.Name}'s current HP: {monster.CurrentHP}");
    }
}
