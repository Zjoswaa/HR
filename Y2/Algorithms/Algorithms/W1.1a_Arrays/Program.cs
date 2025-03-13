//using Solution;

using ToDo;

class MainClass {
    static void Main() {
        DebugArray();
    }

    static void DebugArray() {
        var data = new int[] { 10, 1, 5, 7, 0, -3, 100, 5 };
        IArray1D<int> IArr1D = new Array1D<int>(data);
        var valueToFind = 7;
        var index = IArr1D.Find(valueToFind); //index>=0 if value was found otherwise -1
        Console.WriteLine($"{valueToFind} was found at index {index}");
        valueToFind = 5;
        var offset = 3;
        index = IArr1D.Find(valueToFind, offset);
        Console.WriteLine($"{valueToFind} after offset {offset} was found at index {index}");

        valueToFind = 7;
        offset = 4;
        index = IArr1D.Find(valueToFind, offset);
        //Instead of just looking value of index, apply conditionals 
        Console.WriteLine(
            $"{valueToFind} after offset {offset} was {(index >= 0 ? "$found at index {index}" : "not found")}");
    }
}
