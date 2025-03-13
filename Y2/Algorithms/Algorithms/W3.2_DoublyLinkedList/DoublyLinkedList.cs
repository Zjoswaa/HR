using System.Collections;

namespace Solution;

public class DoublyLinkedList<T> : IDoublyLinkedList<T> where T : IComparable<T> {
    public DoubleNode<T>? First, Last;
    public DoublyLinkedList() => First = Last = null;
    public void Clear() => First = Last = null;

    public DoubleNode<T>? Search(T value) {
        if (First is null) {
            return null;
        }
        DoubleNode<T>? p = First;
        while (p is not null) {
            if (p.Value.Equals(value)) {
                return p;
            }
            p = p.Next;
        }
        return null;
    }

    #region "addNode=> first, last, sorted"

    public void AddFirst(T value) {
        if (First is null) {
            First = Last = new DoubleNode<T>(value);
            return;
        }
        DoubleNode<T> newFirst = new DoubleNode<T>(value, First);
        First.Previous = newFirst;
        First = newFirst;
    }

    public void AddLast(T value) {
        if (Last is null) {
            First = Last = new DoubleNode<T>(value);
            return;
        }
        DoubleNode<T> newLast = new DoubleNode<T>(value, null, Last);
        Last.Next = newLast;
        Last = newLast;
    }

    public void AddSorted(T value) {
        if (First is null) {
            First = Last = new DoubleNode<T>(value);
            return;
        }
        if (First.Value.CompareTo(value) > 0) {
            DoubleNode<T> newNode = new DoubleNode<T>(value, First, null);
            First.Previous = newNode;
            First = newNode;
            return;
        }
        DoubleNode<T> p = First;
        while (p.Next is not null) {
            if (p.Next.Value.CompareTo(value) >= 0) {
                DoubleNode<T> newNode = new DoubleNode<T>(value, p.Next, p);
                p.Next.Previous = newNode;
                p.Next = newNode;
                return;
            }
            p = p.Next;
        }
        AddLast(value);
    }

    #endregion

    public bool Remove(T value) {
        if (First is null) {
            return false;
        }
        DoubleNode<T>? p = First;
        while (p is not null) {
            if (p.Value.CompareTo(value) == 0) {
                // If p is the only element
                if (p.Previous is null && p.Next is null) {
                    First = Last = null;
                    return true;
                }
                // If p is the first element
                if (p.Previous is null) {
                    First = p.Next;
                    First.Previous.Next = null;
                    First.Previous = null;
                    return true;
                }
                // If p is the last element
                if (p.Next is null) {
                    Last = p.Previous;
                    Last.Next.Previous = null;
                    Last.Next = null;
                    return true;
                }
                // Else, p is in the middle
                p.Previous.Next = p.Next;
                p.Next.Previous = p.Previous;
                p.Next = null;
                p.Previous = null;
                return true;
            }
            p = p.Next;
        }
        return false;
    }

    public void Delete(DoubleNode<T> node) {
        if (First is null) {
            return;
        }
        DoubleNode<T>? p = First;
        while (p is not null) {
            if (p.Equals(node)) {
                // If p is the only element
                if (p.Previous is null && p.Next is null) {
                    First = Last = null;
                    return;
                }
                // If p is the first element
                if (p.Previous is null) {
                    First = p.Next;
                    First.Previous.Next = null;
                    First.Previous = null;
                    return;
                }
                // If p is the last element
                if (p.Next is null) {
                    Last = p.Previous;
                    Last.Next.Previous = null;
                    Last.Next = null;
                    return;
                }
                // Else, p is in the middle
                p.Previous.Next = p.Next;
                p.Next.Previous = p.Previous;
                p.Next = null;
                p.Previous = null;
                return;
            }
            p = p.Next;
        }
    }

    public IEnumerator<T> GetEnumerator() {
        DoubleNode<T>? current = First;
        while (current != null) {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
