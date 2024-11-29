class ListWrapper<T> {
    private List<T>? _myList = null;

    public int Count {
        get { return _myList!.Count; }
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

    public int HighestCount<_>(ListWrapper<_> ListWrapper) {
        if (this.Count > ListWrapper.Count) {
            return this.Count;
        }
        return ListWrapper.Count;
    }
}
