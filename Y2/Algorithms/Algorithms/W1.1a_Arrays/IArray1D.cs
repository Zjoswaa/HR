public interface IArray1D<T> where T : IEquatable<T> //IComparable<T>  //INumber //.net7
{
    int Length { get; }
    int Count { get; }

    int Find(T Item, int startIndex = 0);
}
