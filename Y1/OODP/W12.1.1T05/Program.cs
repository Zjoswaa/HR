public class Program {
    static void Main() {
        int[] arr1 = new int[] { 5, 3, 10, -4, 6 };
        ArrayUtils.ReverseArray(arr1);
        ArrayUtils.PrintArray(arr1);

        string[] arr2 = new string[] { "Hello", "World", "!" };
        ArrayUtils.ReverseArray(arr2);
        ArrayUtils.PrintArray(arr2);
    }
}
