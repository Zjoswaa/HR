class GroupedItem {
    public readonly Item MyItem;
    public int Quantity;
    public const int MinQuantity = 1;

    public GroupedItem(Item Item, int Quantity) {
        this.MyItem = Item;
        this.Quantity = Quantity;
    }

    public void SetQuantity(int NewQuantity) {
        this.Quantity = NewQuantity;
    }

    public int GetTotalPrice() {
        return MyItem.Price * Math.Max(MinQuantity, this.Quantity);
    }
}
