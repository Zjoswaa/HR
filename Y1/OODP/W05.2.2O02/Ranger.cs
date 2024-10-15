public class Ranger : Fighter {
    private int Arrows { get; set; }

    public Ranger(string Name, Weapon Weapon, int Arrows) : base(Name, Weapon) {
        if (Weapon is RangedWeapon RangedWeapon) {
            this.AttackRange = RangedWeapon.Range;
        }
        this.Arrows = Arrows;
    }

    public override void EquipMainWeapon(Weapon weapon) {
        if (weapon is RangedWeapon RangedWeapon) {
            this.AttackRange = RangedWeapon.Range;
        }
        MainWeapon = weapon;
    }

    public override int Attack() {
        if (this.MainWeapon is RangedWeapon) {
            return BaseAttack + (MainWeapon is null ? 0 : MainWeapon.Damage);

        }
        if (this.Arrows <= 0) {
            return 0;
        }
        return (int)((BaseAttack + (MainWeapon is null ? 0 : MainWeapon.Damage)) * 0.75);
    }
}
