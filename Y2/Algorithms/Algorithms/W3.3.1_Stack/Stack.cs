namespace Solution;

public class Stack<T> : IStack<T> {
    private T[] items;
    public bool Empty => Count == 0;
    public bool Full => Count == Size;
    public int Count { get; private set; }
    public int Size { get; private set; }

    public Stack(int size = 4) {
        Size = size;
        Count = 0;
        items = new T[size];
    }

    public T? Peek() {
        if (Empty) {
            return default;
        }
        return items[Count - 1];
    }

    public T? Pop() {
        if (Empty) {
            return default;
        }
        T res = items[Count - 1];
        items[Count - 1] = default;
        Count--;
        return res;
    }

    public void Push(T Item) {
        if (Full) {
            Resize();
        }
        items[Count] = Item;
        Count++;
    }

    private void Resize() {
        Size *= 2;
        T[] newItems = new T[Size];
        for (int i = 0; i < items.Length; i++) {
            newItems[i] = items[i];
        }
        items = newItems;
    }
}
