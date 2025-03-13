namespace ToDo;

public class BinarySearch {

    public static int binarySearch<T>(T[] a, T v) where T : IComparable {
        int left = 0;
        int right = a.Length - 1;

        while (left <= right) {
            int middle = (left + right) / 2;
            if (a[middle].CompareTo(v) == -1) {
                left = middle + 1;
            }
            else if (a[middle].CompareTo(v) == 1) {
                right = middle - 1;
            }
            else {
                return middle;
            }
        }
        return -1;
    }

    public static int binarySearchRecursive<T>(T[] a, int low, int high, T v) where T : IComparable {
        Utils.ShowCallStack();
        if (low > high) {
            return -1;
        }
        int middle = (low + high) / 2;
        if (a[middle].CompareTo(v) == -1) {
            return binarySearchRecursive(a, middle + 1, high, v);
        }
        if (a[middle].CompareTo(v) == 1) {
            return binarySearchRecursive(a, low, middle - 1, v);
        }
        return middle;
    }
}
