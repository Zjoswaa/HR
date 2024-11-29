public class Program {
    public static void Main() {
        List<MyGenericList<int>> intLists = new() {
            new MyIntList(new List<int>() { 1, 2, 3 }),
            new MyIntList(new List<int>() { 4, 5, 6, 7 }),
        };
        foreach (var list in intLists) {
            Console.WriteLine(list.Combine());
        }

        List<MyGenericList<bool>> boolLists = new() {
            new MyBoolList(new List<bool>() { true, false, true }),
            new MyBoolList(new List<bool>() { true, true, true, true }),
        };
        foreach (var list in boolLists) {
            Console.WriteLine(list.Combine());
        }
    }
}
