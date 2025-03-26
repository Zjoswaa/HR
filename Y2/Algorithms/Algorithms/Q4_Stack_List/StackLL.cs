namespace Solution;

public class StackLL<T> {
    public Node<T>? Top;

    public int Count => computeCount(Top);

    //Count : to keep track of number of elements in the stack
    public void Push(T val) {
        //ToDo 4.1 : to push the values on top of stack 
        throw new NotImplementedException();
    }

    public T? Pop() {
        //ToDo 4.2: To remove value from the top of a non-empty stack, 
        //default in the case of empty stack 
        throw new NotImplementedException();
    }

    public T? Peek() {
        //ToDo 4.3: To return the value from the top of a non-empty stack, 
        //default in the case of empty stack 
        throw new NotImplementedException();
    }

    //---DO NOT REMOVE/CHANGE THIS METHOD:---
    int computeCount<T>(Node<T> node) => (node == null) ? 0 : 1 + computeCount(node.Next);
}
