using System.Collections;

namespace Solution;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T> {
    public SingleNode<T>? Head;
    private int count;
    public int Count => count;

    public SinglyLinkedList() {
        this.Head = null;
        this.count = 0;
    }
    
    public void AddFirst(T value) {
        if (Head is null) {
            Head = new SingleNode<T>(value);
            count = 1;
            return;
        }
        Head = new SingleNode<T>(value, Head);
        count++;
    }

    public void AddLast(T value) {
        if (Head is null) {
            Head = new SingleNode<T>(value);
            count = 1;
            return;
        }
        SingleNode<T> p = Head;
        while (p.Next is not null) {
            p = p.Next;
        }
        p.Next = new SingleNode<T>(value);
        count++;
    }

    public bool Remove(T value) {
        if (Head is null) {
            return false;
        }
        if (Head.Value.Equals(value)) {
            Head = Head.Next;
            count--;
            return true;
        }
        
        SingleNode<T> p = Head;
        while (p.Next is not null) {
            if (p.Next.Value.Equals(value)) {
                p.Next = p.Next.Next;
                count--;
                return true;
            }
            p = p.Next;
        }
        return false;
    }

    public SingleNode<T>? Search(T value) {
        if (Head is null) {
            return null;
        }
        SingleNode<T>? p = Head;
        while (p is not null) {
            if (p.Value.Equals(value)) {
                return p;
            }
            p = p.Next;
        }
        return null;
    }

    public bool Contains(T value) {
        if (Head is null) {
            return false;
        }
        SingleNode<T>? p = Head;
        while (p is not null) {
            if (p.Value.Equals(value)) {
                return true;
            }
            p = p.Next;
        }
        return false;
    }

    public void AddSorted(T value) {
        if (Head is null) {
            Head = new SingleNode<T>(value);
            count = 1;
            return;
        }
        SingleNode<T> p = Head;
        if (Head.Value.CompareTo(value) == 1) {
            SingleNode<T> newHead = new SingleNode<T>(value);
            newHead.Next = Head;
            Head = newHead;
            count++;
            return;
        }
        while (p.Next is not null) {
            if (p.Value.CompareTo(value) <= 0 && p.Next.Value.CompareTo(value) == 1) {
                SingleNode<T> newNode = new SingleNode<T>(value);
                newNode.Next = p.Next;
                p.Next = newNode;
                count++;
                return;
            }
            p = p.Next;
        }
        p.Next = new SingleNode<T>(value);
        count++;
    }

    public void Clear() {
        Head = null;
        count = 0;
    }

    public IEnumerator<T> GetEnumerator() {
        SingleNode<T>? current = Head;
        while (current != null) {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}
