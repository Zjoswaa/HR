namespace ToDo;

public class Search<T> : ISearch<T> where T : IComparable<T> {

    public static int SequentialSearch(T[] a, T v) {
        for (int i = 0; i < a.Length; i++) {
            if (a[i].Equals(v)) {
                return i;
            }
        }
        return -1;
    }

    public static int BinarySearch(T[] a, T v) {
        int left = 0;
        int right = a.Length - 1;

        while (left <= right) {
            int middle = (left + right) / 2;
            if (a[middle].CompareTo(v) == -1) {
                left = middle + 1;
            } else if (a[middle].CompareTo(v) == 1) {
                right = middle - 1;
            } else {
                return middle;
            }
        }
        return -1;
    }

    public static int BinarySearchRecursive(T[] a, T v, int low, int high) {
        Utils.ShowCallStack();
        if (low > high) {
            return -1;
        }
        int middle = (low + high) / 2;
        if (a[middle].CompareTo(v) == -1) {
            return BinarySearchRecursive(a, v, middle + 1, high);
        }
        if (a[middle].CompareTo(v) == 1) {
            return BinarySearchRecursive(a, v, low, middle - 1);
        }
        return middle;
    }
}
