class GargoyleGoblet : Fighter, ITransform {
    public bool IsTransformed { get; set; }
    public GargoyleGoblet() : base("Gargoyle Goblet") { }

    public override void Transform() => IsTransformed = true;
    public override void Revert() => IsTransformed = false;

    public override int AttackPower => IsTransformed ? 0 : base.AttackPower;
    public void Drink(Fighter fighter) {
        fighter.RegainHealth(fighter.MaxHitPoints);
        if (fighter is Witch witch)
            witch.RecoverMagicPoints(witch.MaxMagicPoints);
    }
}
