using System.Numerics;

namespace ToDo;

public class MultiArray : IMultiArray {
    public static T[]? RowSum<T>(T[,] arr2D) where T : INumber<T> {
        T[] RowSumArray = new T[arr2D.GetLength(0)];
        for (int y = 0; y < arr2D.GetLength(0); y++) {
            T CurrRowSum = default;
            for (int x = 0; x < arr2D.GetLength(1); x++) {
                CurrRowSum += arr2D[y, x];
            }
            RowSumArray[y] = CurrRowSum;
        }
        return RowSumArray;
    }

    public static T[]? ColSum<T>(T[,] arr2D) where T : INumber<T> {
        T[] ColSumArray = new T[arr2D.GetLength(1)];
        for (int x = 0; x < arr2D.GetLength(1); x++) {
            T CurrColSum = default;
            for (int y = 0; y < arr2D.GetLength(0); y++) {
                CurrColSum += arr2D[y, x];
            }
            ColSumArray[x] = CurrColSum;
        }
        return ColSumArray;
    }

    public static Tuple<int, T>? MaxRowIndexSum<T>(T[][] arrJagged) where T : INumber<T> {
        if (arrJagged is null) {
            return null;
        }

        T Max = default;
        int MaxIndex = 0;
        
        for (int y = 0; y < arrJagged.Length; y++) {
            if (arrJagged[y] is not null) {
                T CurrRowSum = default;
                for (int x = 0; x < arrJagged[y].Length; x++) {
                    CurrRowSum += arrJagged[y][x];
                }
                
                if (y == 0) {
                    Max = CurrRowSum;
                }
                else {
                    if (CurrRowSum > Max) {
                        Max = CurrRowSum;
                        MaxIndex = y;
                    }
                }
            }
        }

        return Tuple.Create(MaxIndex, Max);
    }

    public static T?[] MaxCol<T>(T[][] arrJagged) where T : INumber<T> {
        if (arrJagged is null) {
            return null;
        }
        
        // Get widest row width
        int Width = 0;
        foreach (T[] row in arrJagged) {
            if (row is null) {
                continue;
            }
            if (row.Length > Width) {
                Width = row.Length;
            }
        }

        // Calculate sums of every column
        T[] ColSums = new T[Width];
        foreach (T[] row in arrJagged) {
            if (row is null) {
                continue;
            }
            for (int i = 0; i < row.Length; i++) {
                ColSums[i] += row[i];
            }
        }

        // Get the index of the maximum column
        int MaxColIndex = 0;
        T Max = ColSums[0];
        for (int i = 0; i < ColSums.Length; i++) {
            if (ColSums[i] > Max) {
                Max = ColSums[i];
                MaxColIndex = i;
            }
        }

        T[] MaxCol = new T[arrJagged.Length];
        for (int i = 0; i < arrJagged.Length; i++) {
            if (arrJagged[i] is null) {
                continue;
            }
            if (MaxColIndex < arrJagged[i].Length) {
                MaxCol[i] = arrJagged[i][MaxColIndex];
            }
            else {
                MaxCol[i] = default;
            }
        }

        return MaxCol;
    }

    public static T[][]? Split<T>(Tuple<T, T, T>[] input) {
        T[][] SplitArray = new T[3][] {
            new T[input.Length],
            new T[input.Length],
            new T[input.Length]
        };

        for (int i = 0; i < input.Length; i++) {
            SplitArray[0][i] = input[i].Item1;
            SplitArray[1][i] = input[i].Item2;
            SplitArray[2][i] = input[i].Item3;
        }
        
        return SplitArray;
    }

    public static T[,]? Zip<T>(T[] a, T[] b) {
        T[,] ZippedArray = new T[a.Length > b.Length ? a.Length : b.Length, 2];

        for (int i = 0; i < ZippedArray.GetLength(0); i++) {
            if (i < a.Length) {
                ZippedArray[i, 0] = a[i];
            } else {
                ZippedArray[i, 0] = default;
            }

            if (i < b.Length) {
                ZippedArray[i, 1] = b[i];
            } else {
                ZippedArray[i, 1] = default;
            }
        }

        return ZippedArray;
    }
}
