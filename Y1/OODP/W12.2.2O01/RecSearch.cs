static class RecSearch {
    public static int BinarySearch(int[] arr, int value) {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    // Overload BinarySearch here
    private static int BinarySearch(int[] arr, int value, int first, int last) {
        if (first > last) {
            return -1;
        }
        
        int middle = (first + last) / 2;
        if (arr[middle] == value) {
            return middle;
        }

        if (arr[middle] > value) {
            return BinarySearch(arr, value, first, middle - 1);
        }
        else {
            return BinarySearch(arr, value, middle + 1, last);
        }
    }
}
