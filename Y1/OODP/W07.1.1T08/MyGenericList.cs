public abstract class MyGenericList<T> {
    public List<T> Elems;
    protected MyGenericList(List<T> elems) => Elems = elems;
    public abstract T Combine();
}
