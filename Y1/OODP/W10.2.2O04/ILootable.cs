interface ILootable {
    bool IsLootable { get; }
    List<Item> IsLooted();
}
