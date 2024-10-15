public class Weapon {
    public string Name;

    public int _damage;
    public int Damage {
        get => _damage;
        set => _damage = Math.Max(value, 0);
    }

    public Weapon(string name, int damage) {
        Name = name;
        Damage = damage;
    }
}
