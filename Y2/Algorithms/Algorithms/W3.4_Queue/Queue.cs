namespace Solution;

public class Queue<T> : IQueue<T> {
    private int front;
    private int back;
    private T[] data;
    private int count;

    public bool Empty => count == 0;
    public bool Full => count == data.Length;
    public int Count => count;
    public int Size => data.Length;

    public Queue(int capacity = 5) {
        data = new T[capacity];
        count = 0;
        front = 0;
        back = 0;
    }

    public void Enqueue(T element) {
        if (Full || Size == 0) {
            return;
        }
        // If there are no elements yet, insert at the beginning
        if (Count == 0) {
            data[0] = element;
            count++;
            front = 0;
            back = 0;
            return;
        }
        // Else, move every item over to the right
        for (int i = Size - 2; i >= 0; i--) {
            data[i + 1] = data[i];
        }
        // Insert at the start which is now free
        data[0] = element;
        count++;
        front++;
        back = 0;
    }

    public T? Dequeue() {
        if (Empty || Size == 0) {
            return default(T);
        }
        T res = data[front];
        data[front] = default(T);
        count--;
        front--;
        return res;
    }
}
