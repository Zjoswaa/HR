//using Solution;

using ToDo;

class MainClass {
    static void Main() {
        DebugArray();
    }

    static void DebugArray() {
        var data = new int[,] {
            { 1, 2, 3, 4 },
            { 5, 6, 7, -8 },
            { 9, 10, 11, 12 }
        };
        var actualValue = MultiArray.RowSum(data);
        var expectedValue = new int[] { 10, 10, 42 };

    }
}
