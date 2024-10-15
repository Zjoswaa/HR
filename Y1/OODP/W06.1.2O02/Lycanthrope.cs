class Lycanthrope : Fighter, ITransform {
    // Can only transform at night.
    // When transforming, double attack power and maximum HP, and recover all HP.
    public override int MaxHitPoints {
        get => IsTransformed ? base.MaxHitPoints * 2 : base.MaxHitPoints;
        protected set => base.MaxHitPoints = value;
    }
    public override int AttackPower => IsTransformed ? base.AttackPower * 2 : base.AttackPower;

    public Lycanthrope(string name) : base(name) { }

    public override void Transform() {
        if (World.IsDayTime)
            return;
        IsTransformed = true;
        CurrentHitPoints = MaxHitPoints;
    }

    public override void Revert() {
        if (!World.IsDayTime)
            return;
        IsTransformed = false;
    }
}
