namespace ToDo;

public class SequentialSearch {
    public static int sequentialSearch(int[] a, int v) {
        for (int i = 0; i < a.Length; i++) {
            if (a[i].Equals(v)) {
                return i;
            }
        }
        return -1;
    }

    public static int sequentialSearch<T>(T[] a, T v) where T : IComparable {
        for (int i = 0; i < a.Length; i++) {
            if (a[i].Equals(v)) {
                return i;
            }
        }
        return -1;
    }
}
