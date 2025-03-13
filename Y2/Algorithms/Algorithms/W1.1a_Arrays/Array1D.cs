namespace ToDo;

public class Array1D<T> : IArray1D<T> where T : IEquatable<T> {
    protected T[] _data = null!;
    protected int _index;

    public Array1D(int size = 10) {
        _data = new T[size];
        _index = 0;
    }

    public Array1D(T[] data) {
        //Shallow or deep copy here
        _data = data; //Shallow copy
        _index = data.Length;
    }

    public int Length =>
        _data.Length;

    public int Count => 
        _index;

    public int Find(T Item, int startIndex = 0) {
        if (_data is null || Item is null) {
            return -1;
        }
        
        if (Length == 0 || startIndex > Length - 1) {
            return -1;
        }
        
        for (int i = startIndex; i < Length; i++) {
            if (_data[i] is not null && _data[i].Equals(Item)) {
                return i;
            }
        }

        return -1;
    }
}
