namespace Solution;

public static class Q1 {
    public static bool IsSorted<T>(T[] arr) where T : IComparable<T> {
        if (arr is null || arr.Length <= 1) {
            return true;
        }
        for (int i = 1; i < arr.Length; i++) {
            if (arr[i].CompareTo(arr[0]) < 0) {
                return false;
            }
        }
        return true;
    }

    public static int SearchIndex<T>(T[]? arr, T key, Func<T[], bool> checkSorted, Action<T[]> sortArray,
        Func<T[], T, int> search) where T : IComparable<T> {
        if (arr is null) {
            return -1;
        }
        if (!checkSorted(arr)) {
            sortArray(arr);
        }
        return RecursiveBinarySearch(arr, key, 0, arr.Length - 1);
    }

    public static void OrderArray<T>(T[] arr) where T : IComparable<T> {
        // I used insertion sort
        for (int i = 1; i < arr.Length; i++) {
            T key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j].CompareTo(key) == 1) {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    //Do Not change: search method used as one input of method SearchIndex in Program.cs
    public static int Search<T>(T[] arr, T key) where T : IComparable<T> {
        return RecursiveBinarySearch(arr, key, 0, arr.Length - 1);
    }

    private static int RecursiveBinarySearch<T>(T[] arr, T key, int left, int right) where T : IComparable<T> {
        Utils.ShowCallStack(false); //DO NOT comment or remove this line of code
        if (left > right) {
            return -1;
        }
        int middle = (left + right) / 2;
        if (arr[middle].CompareTo(key) == -1) {
            return RecursiveBinarySearch<T>(arr, key, middle + 1, right);
        }
        if (arr[middle].CompareTo(key) == 1) {
            return RecursiveBinarySearch<T>(arr, key, left, middle - 1);
        }
        return middle;
    }
}
