namespace Solution;

public static class Q6 {
    public static T[]? Merge<T>(T[]? one, T[]? two) where T : IComparable<T> {
        // If one of the two input is null, Merge will return null
        if (one is null || two is null) {
            return null;
        }

        // In case one of the two (or both) input refers to an empty array, Merge will return the other one or an empty array
        if (one.Length == 0) {
            return two;
        }
        if (two.Length == 0) {
            return one;
        }

        T[] merged = new T[one.Length + two.Length];
        int oneIdx = 0;
        int twoIdx = 0;
        int mergedIdx = 0;

        while (oneIdx < one.Length && twoIdx < two.Length) {
            if (one[oneIdx].CompareTo(two[twoIdx]) == -1) { // one[onePtr] < two[twoPtr]
                merged[mergedIdx] = one[oneIdx];
                oneIdx++;
            }
            else {
                merged[mergedIdx] = two[twoIdx];
                twoIdx++;
            }
            mergedIdx++;
        }
        
        // Here we reached the end of at least one of the two input arrays, so add all remaining items of the other one to the end of the merged array
        if (oneIdx == one.Length) {
            while (twoIdx < two.Length) {
                merged[mergedIdx] = two[twoIdx];
                twoIdx++;
                mergedIdx++;
            }
        }
        else {
            while (oneIdx < one.Length) {
                merged[mergedIdx] = one[oneIdx];
                oneIdx++;
                mergedIdx++;
            }
        }

        return merged;
    }

    public static T[] Flatten<T>(T?[][]? jagged, Func<T[], T[], T[]> fxMerge) where T : IComparable<T> {
        if (jagged is null || jagged.Length == 0)
            return new T[0];

        T?[] flattened = jagged[0];

        for (int i = 1; i < jagged.Length; i++) {
            flattened = fxMerge(flattened, jagged[i]);
        }

        return flattened;
    }
}
