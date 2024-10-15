using System;

public class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Berserker": TestBerserker(); return;
            case "Ranger": TestRanger(); return;
            case "Ninja": TestNinja(); return;
            default: throw new ArgumentException();
        }
    }

    static void TestBerserker() {
        Weapon mace = new("Mace", 7);
        Weapon club = new("Club", 5);
        Berserker berserker = new("Berserker", mace, club);

        Weapon cleaver = new("Cleaver", 15);
        Fighter boss = new("Big Baddy", cleaver, 200);

        // The berserker goes all-out on the boss until he's
        // drained. He still continues to fight despite this.
        for (int i = 0; i < 8; i++) {
            Battle.Attack(berserker, boss, 1);
            Console.WriteLine(" - " + berserker);
            Console.WriteLine(" - " + boss);
        }
    }

    static void TestRanger() {
        RangedWeapon bow = new("Bow", 7, 8);
        Ranger ranger = new("Ranger", bow, 6);

        Weapon sickle = new("Sickle", 5);
        Fighter henchman = new("Henchman", sickle, 80);

        // The hechman walks towards the ranger, while
        // the ranger pelts him with arrows.
        int distance = 7;
        for (; distance > 1; distance--) {
            Battle.Attack(ranger, henchman, distance);
            Console.WriteLine(" - " + ranger);
            Console.WriteLine(" - " + henchman);
        }

        // Out of arrows, she switches to a dagger.
        ranger.EquipMainWeapon(new Weapon("Dagger", 6));
        Battle.Attack(ranger, henchman, distance);
        Console.WriteLine(" - " + ranger);
        Console.WriteLine(" - " + henchman);
    }

    static void TestNinja() {
        Weapon dagger = new("Knife", 4);
        Ninja ninja = new("Ninja", dagger);

        Weapon cleaver = new("Cleaver", 15);
        Fighter boss = new("Big Baddy", cleaver, 200);

        // The battle starts at a distance of 6. Each 'turn' the boss
        // moves closer by 1, and the two attempt to fight each other.
        // This will continue until either is dead.
        int distance = 6;
        for (; distance > 1 || (ninja.IsAlive && boss.IsAlive); distance -= distance > 1 ? 1 : 0) {
            Battle.Attack(ninja, boss, distance);
            Battle.Attack(boss, ninja, distance);
            Console.WriteLine(" - " + ninja);
            Console.WriteLine(" - " + boss);
            if (ninja.MainWeapon == null)
                ninja.EquipMainWeapon(new Weapon("Dagger", 6));
        }
    }
}
