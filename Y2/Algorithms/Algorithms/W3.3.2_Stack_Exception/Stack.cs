//-----This file HAS to be modified----

public class Stack<T> : SimpleStack<T> {
    public Stack() : base() { }

    public new void Push(T item) {
        if (top == Capacity - 1) {
            Capacity *= 2;
            T?[] old = arr;
            arr = new T[Capacity];
            for (int i = 0; i < old.Length; i++) {
                arr[i] = old[i];
            }
        }
        arr[++top] = item;
    }

    public new T? Peek() {
        if (top == -1) {
            throw new StackEmptyException("The Stack is empty.");
        }
        return arr[top];
    }

    public new T? Pop() {
        if (top == -1) {
            throw new StackEmptyException("The Stack is empty.");
        }
        T? temp = arr[top];
        arr[top] = default(T);
        top--;
        return temp;
    }
}
