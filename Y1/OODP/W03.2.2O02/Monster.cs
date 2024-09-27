class Monster {
    public readonly string Name;
    public int CurrentHP;
    public int Strength;
    public int Experience;

    public Monster(string Name, int CurrentHP, int Strength, int Experience) {
        this.Name = Name;
        this.CurrentHP = CurrentHP;
        this.Strength = Strength;
        this.Experience = Experience;
    }

    public bool IsAlive() {
        return this.CurrentHP > 0;
    }

    public void Attack(Player Player) {
        Player.TakeDamage(this.Strength);
    }

    public void TakeDamage(int Damage) {
        this.CurrentHP = Math.Max(0, this.CurrentHP - Damage);
    }
}
