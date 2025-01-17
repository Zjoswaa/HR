class Item<T> {
    public T Value { get; }
    public List<Item<T>>? SubItems { get; }

    public Item(T value, List<Item<T>>? sub = null) {
        Value = value;
        SubItems = sub;
    }
}
