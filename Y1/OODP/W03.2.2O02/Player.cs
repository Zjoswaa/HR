class Player {
    public const string Name = "Simon Belmont";
    public int MaxHP;
    public int CurrentHP;
    public int Strength;
    public static int Experience = 0;
    private int CurrentLevel = 1;

    public Player(int MaxHP, int Strength) {
        this.MaxHP = MaxHP;
        this.CurrentHP = MaxHP;
        this.Strength = Strength;
        this.LevelUpCheck();
    }

    public void Attack(Monster Monster) {
        Monster.TakeDamage(this.Strength);
        if (Monster.CurrentHP == 0) {
            Experience += Monster.Experience;
        }
        this.LevelUpCheck();
    }

    public void TakeDamage(int Damage) {
        int ReducedDamage = Math.Max(0, (int)Math.Floor((double)Damage - (this.Strength / 4)));
        this.CurrentHP = Math.Max(0, this.CurrentHP - ReducedDamage);
    }

    public bool IsAlive() {
        return this.CurrentHP > 0;
    }

    public int GetLevel() {
        return this.CurrentLevel;
    }

    private void LevelUpCheck() {
        for (int i = 0; i < 7; i++) {
            if (CurrentLevel == i + 1 && Experience >= World.ExperienceChart[i]) {
                this.LevelUp();
            }
        }
    }

    private void LevelUp() {
        this.CurrentLevel++;
        this.MaxHP += 10;
        this.Strength += 3;
    }
}
