static class ShoppingCart {
    public static readonly List<GroupedItem> ItemsToOrder = [];

    public static void AddItem(Item Item, int Quantity) {
        foreach (GroupedItem GroupedItem in ItemsToOrder) {
            if (GroupedItem.MyItem.Name == Item.Name) {
                GroupedItem.Quantity = Math.Max(GroupedItem.MinQuantity, GroupedItem.Quantity + Quantity);
                return;
            }
        }
        ItemsToOrder.Add(new GroupedItem(Item, Math.Max(GroupedItem.MinQuantity, Quantity)));
    }

    public static void IncrementItemQuantity(string ItemName) {
        foreach (GroupedItem GroupedItem in ItemsToOrder) {
            if (GroupedItem.MyItem.Name == ItemName) {
                GroupedItem.Quantity++;
                return;
            }
        }
        Console.WriteLine($"Item {ItemName} not found");
    }

    public static void DecrementItemQuantity(string ItemName) {
        foreach (GroupedItem GroupedItem in ItemsToOrder) {
            if (GroupedItem.MyItem.Name == ItemName) {
                GroupedItem.Quantity = Math.Max(GroupedItem.MinQuantity, GroupedItem.Quantity - 1);
                return;
            }
        }
        Console.WriteLine($"Item {ItemName} not found");
    }

    public static void SetItemQuantity(string ItemName, int NewQuantity) {
        foreach (GroupedItem GroupedItem in ItemsToOrder) {
            if (GroupedItem.MyItem.Name == ItemName) {
                GroupedItem.Quantity = Math.Max(GroupedItem.MinQuantity, NewQuantity);
                return;
            }
        }
        Console.WriteLine($"Item {ItemName} not found");
    }

    public static void RemoveItem(string ItemName) {
        if (ItemsToOrder.RemoveAll(i => i.MyItem.Name == ItemName) == 0) {
            Console.WriteLine($"Item {ItemName} not found");
        }
    }

    public static void EmptyCart() {
        ItemsToOrder.Clear();
    }

    public static void Checkout() {
        int TotalPrice = 0;
        foreach (GroupedItem GroupedItem in ItemsToOrder) {
            TotalPrice += GroupedItem.MyItem.Price * GroupedItem.Quantity;
        }
        EmptyCart();
        Console.WriteLine($"The total price is {TotalPrice}. Thank you!");
    }

    public static void Checkout(GroupedItem GroupedItem) {
        int TotalPrice = GroupedItem.MyItem.Price * Math.Max(GroupedItem.MinQuantity, GroupedItem.Quantity);
        Console.WriteLine($"The price is {TotalPrice}. Thank you!");
    }
}
