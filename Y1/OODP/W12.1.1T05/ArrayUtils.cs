public static class ArrayUtils {
    public static void ReverseArray<T>(T[] arr) {
        RecReverseArray(arr, 0, arr.Length - 1);
    }

    //RecReverseArray goes here
    static void RecReverseArray<T>(T[] arr, int i, int j) {
        if (i >= j) {
            return;
        }
        
        // Swap the values
        (arr[i], arr[j]) = (arr[j], arr[i]);
        
        RecReverseArray<T>(arr, i + 1, j - 1);
    }

    public static void PrintArray<T>(T[] arr) {
        foreach (T elem in arr) {
            Console.WriteLine(elem);
        }
    }
}
