class ListWrapper<T> {
    private List<T>? _myList = null;
    public int Count {
        get {
            return _myList!.Count;
        }
    }

    public ListWrapper() {
        _myList = new();
    }

    public void Add(T Item) {
        _myList?.Add(Item);
    }

    public T Get(int Index) {
        return _myList!.ElementAt(Index);
    }
}
