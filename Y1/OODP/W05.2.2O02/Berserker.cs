public class Berserker : Fighter {
    public Weapon SecondaryWeapon { get; private set; }

    public Berserker(string Name, Weapon MainWeapon, Weapon SecondaryWeapon) : base(Name, MainWeapon) {
        this.SecondaryWeapon = SecondaryWeapon;
    }

    public void EquipSecondaryWeapon(Weapon weapon) {
        if (weapon is RangedWeapon) {
            return;
        }
        SecondaryWeapon = weapon;
    }

    public override int Attack() {
        if (this.HP > 20) {
            this.HP -= 20;
            return (BaseAttack * 2 + (MainWeapon is null ? 0 : MainWeapon.Damage) + (SecondaryWeapon is null ? 0 : SecondaryWeapon.Damage)) * 2;
        }
        return BaseAttack * 2 + (MainWeapon is null ? 0 : MainWeapon.Damage) + (SecondaryWeapon is null ? 0 : SecondaryWeapon.Damage);
    }
}
