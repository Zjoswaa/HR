static class HOF {
    public static T[] Filter<T>(T[] array, Func<T, bool> predicate) {
        return FilterRecursive(array, predicate, 0);
    }

    private static T[] FilterRecursive<T>(T[] array, Func<T, bool> predicate, int index) {
        if (index == array.Length) {
            return [];
        }
        
        if (predicate(array[index])) {
            T[] rest = FilterRecursive(array, predicate, index + 1);
            return new T[] { array[index] }.Concat(rest).ToArray();
        }
        return FilterRecursive(array, predicate, index + 1);
    }
}
