// See https://aka.ms/new-console-template for more information

using System.Numerics;

public interface INumArray1D<T> : IArray1D<T> where T : INumber<T> {
    T? Aggregate(Func<T, T, T> fx);
    T? Sum();
    T? Min();
    T? Max();
    T? Product(bool IgnoreZeros = true);
}
