class MagicItem : Item {
    public readonly string EffectDescription;

    public MagicItem(Item Item, string EffectDescription) : base(Item.Name, Item.Price * 5) {
        this.EffectDescription = EffectDescription;
    }

    public MagicItem(string Name, int Price, string EffectDescription) : base(Name, Price) {
        this.EffectDescription = EffectDescription;
    }
}
