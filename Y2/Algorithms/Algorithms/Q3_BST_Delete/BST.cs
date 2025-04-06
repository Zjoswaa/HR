namespace Solution;

public class BST<T> where T : IComparable<T> {
    public TreeNode<T>? Root { get; set; }

    public void Insert(T value) => Insert(value, Root);

    private void Insert(T value, TreeNode<T>? node) {
        if (Root == null) {
            Root = new TreeNode<T>(value);
            return;
        }
        else {
            if (value.CompareTo(node.Value) > 0) // right child
            {
                if (node.Right == null) {
                    node.Right = new TreeNode<T>(value, node);
                }
                else {
                    Insert(value, node.Right);
                }
            }
            else if (value.CompareTo(node.Value) < 0) //left child
            {
                if (node.Left == null) {
                    node.Left = new TreeNode<T>(value, node);
                }
                else {
                    Insert(value, node.Left);
                }
            }
        }
    }

    public bool Contains(T value) =>
        Search(Root, value) == null ? false : Search(Root, value)?.Value.CompareTo(value) == 0;

    public TreeNode<T>? Search(TreeNode<T>? node, T value) {
        if (node == null) // node does not exist
            return null;

        if (value.CompareTo(node.Value) == 0) // value in the node is the same we are looking for
            return node;

        if (value.CompareTo(node.Value) > 0) // value in the node is smaller than the one we are looking for
            return Search(node.Right, value);

        return Search(node.Left, value);
    }

    #region Remove Delete

    public bool Remove(T value) => Delete(value, findInOrderPredecessor, findInOrderSuccessor);

    public bool Delete(T value, Func<TreeNode<T>, TreeNode<T>?> findInOrderPredecessorFunc, Func<TreeNode<T>, TreeNode<T>?> findInOrderSuccessorFunc) {
        if (Root == null)
            return false;

        TreeNode<T> nodeToDelete = Search(Root, value);

        if (nodeToDelete == null)
            return false;

        TreeNode<T>? parent = nodeToDelete.Parent;

        // CASE 1, 2 : ONE CHILD, LEAF
        if (nodeToDelete.Left == null || nodeToDelete.Right == null) {
            //------One------
            if (nodeToDelete.Left != null && nodeToDelete.Right == null) {
                if (nodeToDelete.Value.CompareTo(Root.Value) == 0) { //nodeToDelete == Root
                    Root = Root.Left;
                    Root.Parent = null;
                    return true;
                }

                if (isLeft(nodeToDelete, parent)) {
                    parent.Left = nodeToDelete.Left;
                }
                else {
                    parent.Right = nodeToDelete.Left;
                }
                nodeToDelete.Left.Parent = parent;
                return true;
            }

            if (nodeToDelete.Right != null && nodeToDelete.Left == null) {
                if (nodeToDelete.Value.CompareTo(Root.Value) == 0) { //nodeToDelete == Root
                    Root = Root.Right;
                    Root.Parent = null;
                    return true;
                }

                if (isLeft(nodeToDelete, parent)) {
                    parent.Left = nodeToDelete.Right;
                }
                else {
                    parent.Right = nodeToDelete.Right;
                }
                nodeToDelete.Right.Parent = parent;
                return true;
            }
            //----------------

            //------None------
            if (nodeToDelete.Value.CompareTo(Root.Value) == 0) { //nodeToDelete == Root
                Root = null;
                return true;
            }

            if (isLeft(nodeToDelete, parent)) {
                parent.Left = null;
            }
            else {
                parent.Right = null;
            }

            return true;
            //----------------
        }

        // CASE 3 : TWO CHILDREN ToDo 3.1
        var successor = findInOrderSuccessorFunc(nodeToDelete);
        nodeToDelete.Value = successor.Value;
        if (isLeft(successor, successor.Parent)) {
            successor.Parent.Left = null;
        }
        else {
            successor.Parent.Right = null;
        }
        successor.Parent = null;
        return true;
    }

    // this methods finds the in order successor of the node given as parameter
    public TreeNode<T>? findInOrderSuccessor(TreeNode<T> node) {
        TreeNode<T> p = node;
        p = p.Right;
        while (p.Left is not null) {
            p = p.Left;
        }
        return p;
    }

    // this methods finds the in order predecessor of the node given as parameter
    public TreeNode<T>? findInOrderPredecessor(TreeNode<T> node) {
        TreeNode<T> p = node;
        p = p.Left;
        while (p.Right is not null) {
            p = p.Right;
        }
        return p;
    }

    // this methods checks if the node given as first parameter is the left child of the node given as second parameter ("parent"). 
    // Remember to do a comparison based on the values of the nodes.
    private bool isLeft(TreeNode<T> node, TreeNode<T> parent) {
        return parent.Left != null && parent.Left.Value.CompareTo(node.Value) == 0;
    }

    #endregion

    #region Traversal

    public List<T>? Traversal(TraversalOrder traversalOrder) =>
        Traversal(traversalOrder, Root, new List<T>());

    List<T>? Traversal(TraversalOrder traversalOrder, TreeNode<T>? currNode, List<T> res) {
        if (currNode == null)
            return default;

        if (traversalOrder == TraversalOrder.InOrder || traversalOrder == TraversalOrder.PostOrder)
            Traversal(traversalOrder, currNode.Left, res);
        if (traversalOrder == TraversalOrder.PostOrder)
            Traversal(traversalOrder, currNode.Right, res);

        res.Add(currNode.Value);

        if (traversalOrder == TraversalOrder.PreOrder)
            Traversal(traversalOrder, currNode.Left, res);
        if (traversalOrder == TraversalOrder.InOrder || traversalOrder == TraversalOrder.PreOrder)
            Traversal(traversalOrder, currNode.Right, res);
        return res;
    }

    #endregion
}