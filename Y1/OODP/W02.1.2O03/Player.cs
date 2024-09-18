public class Player {
    public string Name;
    public int HealthPoints;
    public int Power;

    public Player(string Name, int Power) {
        this.Name = Name;
        this.HealthPoints = 100;
        this.Power = Power;
    }

    public bool IsAlive() {
        return this.HealthPoints > 0;
    }

    public void TakeDamage(int Damage) {
        this.HealthPoints = Math.Max(0, this.HealthPoints - Damage);
    }
}
