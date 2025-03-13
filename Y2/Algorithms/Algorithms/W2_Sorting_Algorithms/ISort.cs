public interface ISort<T> where T : IComparable<T> {
    static abstract void InsertionSort(T[] data);
    static abstract void BubbleSort(T[] data);
    static abstract void MergeSort(T[] data, int low, int high);
}
