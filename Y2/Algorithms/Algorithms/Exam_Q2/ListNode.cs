public class ListNode<T> where T : IComparable {
    public T Value;
    public ListNode<T>? Tail;

    public ListNode(T _value, ListNode<T>? _tail) {
        Value = _value;
        Tail = _tail;
    }
}
