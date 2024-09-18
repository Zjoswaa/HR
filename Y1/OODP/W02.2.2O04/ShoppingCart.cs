class ShoppingCart {
    public List<GroupedShopItem> Groceries;

    public ShoppingCart() {
        this.Groceries = new();
    }

    public void AddItem(ShopItem Item) {
        foreach (GroupedShopItem GroupedItem in this.Groceries) {
            if (GroupedItem.Item.ID == Item.ID) {
                GroupedItem.Quantity++;
                return;
            }
        }
        this.Groceries.Add(new GroupedShopItem(Item));
    }

    public GroupedShopItem FindItem(ShopItem Item) {
        foreach (GroupedShopItem GroupedItem in this.Groceries) {
            if (GroupedItem.Item.ID == Item.ID) {
                return GroupedItem;
            }
        }
        return null;
    }

    public string Contents() {
        string ContentsString = "";
        foreach (GroupedShopItem GroupedItem in this.Groceries) {
            ContentsString += $"{GroupedItem.Item.Name} x {GroupedItem.Quantity}\n";
        }
        return ContentsString;
    }

    public double TotalPrice() {
        double Total = 0.0;
        foreach (GroupedShopItem GroupedItem in this.Groceries) {
            Total += GroupedItem.Item.Price * GroupedItem.Quantity;
        }
        return Total;
    }
}
