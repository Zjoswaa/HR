namespace Exam;

public class Helper {
    public const string undefined = "<NO_VALUE>";

    public static void Display<T>(IEnumerable<T> Array)
        => Console.WriteLine(string.Join(", ", Array));

    public static Action<T> printElement<T>(int n) =>
        (T s) => Console.Write(String.Concat(Enumerable.Repeat(" ", n - s.ToString().Length)) + s.ToString() + ",");

    public static void Display<T>(IEnumerable<T> Array, int maxLengthElement) {
        if (Array != null)
            Array.ToList().ForEach(printElement<T>(maxLengthElement));
        Console.WriteLine();
    }

    public static void Display<T>(T[,] Matrix) {
        var maxLengthElement = Matrix.Cast<T>().ToArray().Select(_ => _.ToString().Length).Max();
        for (int i = 0; i < Matrix.GetLength(0); i++)
            Display(GetRow(Matrix, i), maxLengthElement + 2);
    }

    public static void Display<T>(T[][] JaggedArr) {
        var maxLengthElement = JaggedArr.Select(_ => _ == null ? undefined.Length :
            _.Length == 0 ? undefined.Length :
            _.Select(__ => __.ToString().Length).Max()).Max();

        var maxColumns = JaggedArr.Select(_ => _ == null ? 0 : _.Length).Max();

        var EmptyArray = Enumerable.Repeat(default(T), maxColumns).ToArray();

        for (int i = 0; i < JaggedArr.Length; i++) {
            if (JaggedArr[i] != null && JaggedArr[i].Length != 0) {
                var paddedList = JaggedArr[i].ToList();
                paddedList.AddRange(Enumerable.Repeat(default(T), maxColumns - JaggedArr[i].Length));
                Display(paddedList.ToArray(), maxLengthElement + 2);
            }
            else
                Display(EmptyArray, maxLengthElement + 2);
        }
    }

    public static IEnumerable<T> GetRow<T>(T[,] Matrix, int rowIndex)
        => Enumerable.Range(0, Matrix.GetLength(1))
            .Select(_ => Matrix[rowIndex, _]).ToArray();
}