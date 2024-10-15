public static class Battle {
    public static void Attack(Fighter attacker, Fighter defender, int distance) {
        if (!attacker.IsAlive) {
            Console.WriteLine($"{attacker.Name} is dead and cannot attack"); ;
            return;
        }
        if (!defender.IsAlive) {
            Console.WriteLine($"{defender.Name} is dead and cannot defend"); ;
            return;
        }

        if (attacker.AttackRange < distance) {
            Console.WriteLine($"Defender {defender.Name} is out of range");
            return;
        }

        int damage;
        if (attacker is Ninja ninja) {
            damage = ninja.Attack(distance);
        } else {
            damage = attacker.Attack();
        }
        defender.TakeDamage(damage);
        Console.WriteLine($"{attacker.Name} dealt {damage} damage to {defender.Name} at {distance} distance");
    }
}
