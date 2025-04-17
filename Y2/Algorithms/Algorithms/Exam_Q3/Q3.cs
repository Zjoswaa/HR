namespace Solution;

public class BST<T> where T : IComparable<T> {
    public TreeNode<T>? Root { get; set; }

    public T[]? BFT() {
        if (Root is null) {
            return null;
        }

        int Count = 0;
        T[] res = new T[Count];

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(Root);

        while (queue.Count != 0) {
            TreeNode<T> node = queue.Dequeue();

            // Increase array size by 1
            T[] newRes = new T[++Count];
            for (int i = 0; i < res.Length; i++) {
                newRes[i] = res[i];
            }
            res = newRes;

            res[Count - 1] = node.Value;

            if (node.Left is not null) {
                queue.Enqueue(node.Left);
            }
            if (node.Right is not null) {
                queue.Enqueue(node.Right);
            }
        }
        return res;
    }
}
