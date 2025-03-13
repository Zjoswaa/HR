//-----This file HAS to be modified----

public class SimpleStack<T> {
    protected T?[] arr;
    protected int top;
    public int Capacity { get; protected set; }

    public SimpleStack() {
        Capacity = 4;
        arr = new T[Capacity];
        top = -1;
    }

    public bool IsEmpty() {
        return top == -1;
    }

    public void Push(T item) //change something here
    {
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

    public T? Peek() //change something here
    {
        if (IsEmpty())
            throw new StackEmptyException("The Stack is empty.");
        return arr[top];
    }

    public T? Pop() //change something here
    {
        if (IsEmpty())
            throw new StackEmptyException("The Stack is empty.");
        T? temp = arr[top];
        arr[top] = default(T);
        top--;
        return temp;
    }
}