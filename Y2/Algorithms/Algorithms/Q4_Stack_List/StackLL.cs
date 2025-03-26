namespace Solution;

public class StackLL<T> {
    public Node<T>? Top = null;

    public int Count => computeCount(Top);

    public void Push(T val) {
        Top = new Node<T>(val, Top);
    }

    public T? Pop() {
        if (Top == null) {
            return default;
        }
        T res = Top.Value;
        Top = Top.Next;
        return res;
    }

    public T? Peek() {
        return Count == 0 ? default : Top.Value;
    }

    //---DO NOT REMOVE/CHANGE THIS METHOD:---
    int computeCount<T>(Node<T> node) => (node == null) ? 0 : 1 + computeCount(node.Next);
}
