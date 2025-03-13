using System.Numerics;

public interface IMultiArray {
    //2D Array
    //RowSum
    static abstract T[]? RowSum<T>(T[,] arr2D) where T : INumber<T>;

    //ColumSum
    static abstract T[]? ColSum<T>(T[,] arr2D) where T : INumber<T>;

    //Jagged Array
    //Row with Highest sum
    static abstract Tuple<int, T>? MaxRowIndexSum<T>(T[][] arrJagged) where T : INumber<T>;

    //Column with Highest sum 
    static abstract T?[] MaxCol<T>(T[][] arrJagged) where T : INumber<T>;

    //Split e.g. Tuple<int, int, int>[] RGB int [] R-value, [] G-values, [] B-values
    static abstract T[][]? Split<T>(Tuple<T, T, T>[] input);

    //Zip e.g  a = [1, 2, 3], b = [10, 12, 13] ==> [[1, 10], [2, 12], [3, 13]]
    static abstract T[,]? Zip<T>(T[]? a, T[]? b);
}
