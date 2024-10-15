public class Ninja : Fighter {
    public Ninja(string Name, Weapon Weapon) : base(Name, Weapon) {
        this.AttackRange = 5;
    }

    public int Attack(int Distance) {
        if (Distance > 1) {
            int Damage = (BaseAttack + (MainWeapon is null ? 0 : MainWeapon.Damage)) * 4;
            this.MainWeapon = null;
            return Damage;
        }
        return BaseAttack + (MainWeapon is null ? 0 : MainWeapon.Damage);
    }
}
