namespace Solution;

public class MySinglyLinkedList<T> where T : IComparable {
    public ListNode<T>? Head;

    public MySinglyLinkedList(ListNode<T>? list = null) {
        Head = list;
    }

    public void AddAfter(T value, ListNode<T>? prevNode) {
        if (prevNode is null) {
            return;
        }
        if (prevNode.Tail is null) {
            prevNode.Tail = new ListNode<T>(value, null);
            return;
        }
        prevNode.Tail = new ListNode<T>(value, prevNode.Tail);
    }

    public void AddSortedRange(T[] values, Action<T, ListNode<T>> addAfterFunc) {
        foreach (T value in values) {
            if (Head is null) {
                Head = new ListNode<T>(value, null);
                continue;
            }
            if (value.CompareTo(Head.Value) < 0) {
                Head = new ListNode<T>(value, Head);
                continue;
            }

            ListNode<T> p = Head;
            while (p.Tail is not null && p.Tail.Value.CompareTo(value) < 0) {
                p = p.Tail;
            }
            addAfterFunc(value, p);
        }
    }

    public string Display() {
        return Display(Head);
    }

    private string Display(ListNode<T>? node, string init = "") =>
        node == null ? init : Display(node.Tail, init + node.Value + (node.Tail != null ? ", " : ""));
}
