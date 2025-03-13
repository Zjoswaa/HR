using System.Numerics;

namespace ToDo;

public class NumArray1D<T> : Array1D<T>, INumArray1D<T> where T : IComparable<T>, INumber<T> {
    public NumArray1D(int size = 10) : base(size) { }
    public NumArray1D(T[] data) : base(data) { }

    public T? Aggregate(Func<T, T, T> fx) {
        T sum = _data[0];

        for (int i = 1; i < Length; i++) {
            sum = fx(sum, _data[i]);
        }

        return sum;
    }

    public T? Max() {
        T Max = _data[0];

        for (int i = 0; i < Length; i++) {
            if (_data[i] > Max) {
                Max = _data[i];
            }
        }

        return Max;
    }

    public T? Min() {
        T Min = _data[0];

        for (int i = 0; i < Length; i++) {
            if (_data[i] < Min) {
                Min = _data[i];
            }
        }

        return Min;
    }

    public T? Product(bool IgnoreZeros = true) {
        T Product = _data[0];
    
        for (int i = 1; i < Length; i++) {
            if (!(_data[i].Equals(0) && IgnoreZeros)) {
                Product *= _data[i];
            }
        }

        return Product;
    }

    public T? Sum() {
        T Sum = _data[0];
        
        for (int i = 1; i < Length; i++) {
            Sum += _data[i];
        }

        return Sum;
    }
}
