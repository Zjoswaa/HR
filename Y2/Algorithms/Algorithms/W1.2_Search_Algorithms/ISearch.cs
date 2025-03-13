public interface ISearch<T> where T : IComparable<T> {
    static abstract int SequentialSearch(T[] data, T Item);
    static abstract int BinarySearch(T[] data, T Item);
    static abstract int BinarySearchRecursive(T[] data, T Item, int low, int high);
}
