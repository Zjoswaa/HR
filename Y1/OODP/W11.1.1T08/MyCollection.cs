public class MyCollection {
    private int[] _data;
    public MyCollection(int size) => _data = new int[size];

    // Overload the [] indexer here
    public int this[int i] {
        get {
            return _data[i];
        }
        set {
            _data[i] = value;
        }
    }
}
