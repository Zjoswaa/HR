static class ArrayUtils {
    public static int FindMinimum(int[] arr) {
        return RecMinimum(arr, arr.Length - 1);
    }

    private static int RecMinimum(int[] arr, int i) {
        if (i < 0) {
            return arr[0];
        }

        return Math.Min(arr[i], RecMinimum(arr, i - 1));
    }
}
