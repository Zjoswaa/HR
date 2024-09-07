Random random = new();

int attack = 50;
double critChance = 0.33;
int bossHP = 1000;

while(bossHP > 0) {
    Console.WriteLine($"Boss HP: {bossHP}");
    int damage = attack;
    if (random.NextDouble() <= critChance) {
        damage *= 2;
    }
    Console.WriteLine($"Damage: {damage}");
    Console.WriteLine();
    bossHP -= damage;
}
Console.Write("Boss defeated");
