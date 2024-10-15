public class RangedWeapon : Weapon {
    public int Range { get; private set; }

    public RangedWeapon(string Name, int Damage, int Range) : base(Name, Damage) {
        this.Range = Range;
    }
}
