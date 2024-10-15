class Witch : Fighter {
    public override int MaxHitPoints => 80;

    public int MaxMagicPoints => 100;
    private int _currentMagicPoints;
    public int CurrentMagicPoints {
        get => _currentMagicPoints;
        private set => _currentMagicPoints = Math.Clamp(value, 0, MaxMagicPoints);
    }

    // Attack power is decreased while transformed into a raven.
    // Attack power is increased by the familiar, if any.
    public override int AttackPower => (IsTransformed ? 1 : 5) + (MyFamiliar?.Attack ?? 0);

    public Familiar MyFamiliar { get; set; }

    public Witch(string name, Familiar familiar) : base(name) {
        MyFamiliar = familiar;
        CurrentMagicPoints = MaxMagicPoints;
    }

    public override void Transform() {
        if (CurrentMagicPoints < 10)
            return; // Not enough MP to transform into a raven

        CurrentMagicPoints -= 10;
        IsTransformed = true;
    }

    public override void Revert() => IsTransformed = false; // Reverting costs no MP

    public void Enchant(List<ITransform> targets) {
        // First calculate the total MP cost
        int totalMPCost = 0;
        foreach (var fighter in targets) {
            totalMPCost += 10;
        }
        if (CurrentMagicPoints < totalMPCost)
            return; // Not enough MP; not casting the spell on any target

        CurrentMagicPoints -= totalMPCost;
        foreach (var fighter in targets) {
            fighter.Transform();
        }
    }

    public void Disenchant(List<ITransform> targets) {
        int totalMPCost = 0;
        foreach (var fighter in targets) {
            totalMPCost += 10;
        }
        if (CurrentMagicPoints < totalMPCost)
            return;

        CurrentMagicPoints -= totalMPCost;
        foreach (var fighter in targets) {
            fighter.Revert();
        }
    }

    public void RecoverMagicPoints(int amount) {
        if (amount < 0)
            throw new ArgumentException(
                $"Invalid amount: {amount}. Magic recovered must be non-negative.");
        CurrentMagicPoints += amount;
    }
}
