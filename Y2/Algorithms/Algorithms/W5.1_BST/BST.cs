namespace Solution;

public class BST<T> : IBST<T> where T : IComparable<T> {
    public TreeNode<T>? Root { get; set; }

    public void Insert(T value) => Insert(value, Root);

    public void InsertIterative(T value) {
        if (Root is null) {
            Root = new TreeNode<T>(value);
            return;
        }
        TreeNode<T> p = Root;

        while (true) {
            // If value == p.Value
            if (value.Equals(p.Value)) {
                return;
            }
            // If value > p.Value
            if (value.CompareTo(p.Value) == 1) {
                // If p has no right child yet
                if (p.Right is null) {
                    // Create a right child
                    p.Right = new TreeNode<T>(value, p);
                    return;
                }
                // If p has a right child
                p = p.Right;
            }
            // If value < p.Value
            else {
                // If p has no left child yet
                if (p.Left is null) {
                    // Create a left child
                    p.Left = new TreeNode<T>(value, p);
                    return;
                }
                p = p.Left;
            }
        }
    }

    private void Insert(T value, TreeNode<T>? node) {
        if (Root is null) {
            Root = new TreeNode<T>(value);
            return;
        }

        // If value > node.Value
        if (value.CompareTo(node.Value) == 1) {
            if (node.Right is null) {
                node.Right = new TreeNode<T>(value, node);
            }
            else {
                Insert(value, node.Right);
            }
        }
        // If value < node.Value
        else if (value.CompareTo(node.Value) == -1) {
            if (node.Left is null) {
                node.Left = new TreeNode<T>(value, node);
            }
            else {
                Insert(value, node.Left);
            }
        }
    }

    #region Traversal

    public string PreOrderTraversal() => PreOrderTraversal(Root);

    private string PreOrderTraversal(TreeNode<T>? currNode) {
        if (currNode == null)
            return "";

        string s = currNode.Value.ToString() + " ";
        s += PreOrderTraversal(currNode.Left);
        s += PreOrderTraversal(currNode.Right);

        return s;
    }

    public string InOrderTraversal() => InOrderTraversal(Root);

    private string InOrderTraversal(TreeNode<T>? currNode) {
        if (currNode == null)
            return "";

        string s = "";
        s += InOrderTraversal(currNode.Left);
        s += currNode.Value.ToString() + " ";
        s += InOrderTraversal(currNode.Right);

        return s;
    }

    public string PostOrderTraversal() => PostOrderTraversal(Root);

    private string PostOrderTraversal(TreeNode<T>? currNode) {
        if (currNode == null)
            return "";

        string s = "";
        s += PostOrderTraversal(currNode.Left);
        s += PostOrderTraversal(currNode.Right);
        s += currNode.Value.ToString() + " ";

        return s;
    }

    #endregion

    public bool Contains(T value) {
        return Search(Root, value) is not null;
    }

    private TreeNode<T>? Search(TreeNode<T>? node, T value) {
        if (node is null) {
            return null;
        }

        // value in the node is the same we are looking for
        if (node.Value.CompareTo(value) == 0) {
            return node;
        }

        // value in the node is smaller than the one we are looking for
        if (node.Value.CompareTo(value) == -1) {
            return Search(node.Right, value);
        }

        // value in the node is bigger than the one we are looking for
        return Search(node.Left, value);
    }

    #region Remove Delete

    public bool Remove(T value) {
        return DeleteValue(value);
    }

    public bool DeleteValue(T value) {
        if (Root == null) return false;
        TreeNode<T> node = Search(Root, value);
        if (node == null) return false;
        // special case if the value to delete is in the root (and the root has 0 children or 1 child)

        // there are no children:
        if (node.Left == null && node.Right == null) {
            if (node.Value.CompareTo(Root.Value) == 0) { //node == Root
                Root = null;
                return true;
            }

            if (IsLeft(node, node.Parent)) {
                node.Parent.Left = null;
            }
            else {
                node.Parent.Right = null;
            }

            return true;
        }

        // there is only left child, the right does not exist
        // there is only right child, the left does not exist

        if (node.Left == null && node.Right != null || node.Left != null && node.Right == null) {
            if (node.Value.CompareTo(Root.Value) == 0) { //node == Root
                if (node.Left != null) {
                    node.Left.Parent = null;
                    Root = node.Left;
                }
                else { //node.Right != null
                    node.Right.Parent = null;
                    Root = node.Right;
                }
                return true;
            }

            if (node.Left != null) {
                if (IsLeft(node, node.Parent)) {
                    node.Parent.Left = node.Left;
                    node.Left.Parent = node.Parent;
                }
                else {
                    node.Parent.Right = node.Left;
                    node.Left.Parent = node.Parent;
                }
                return true;
            } 
            //node.Right != null
            if (IsLeft(node, node.Parent)) {
                node.Parent.Left = node.Right;
                node.Right.Parent = node.Parent;
            }
            else {
                node.Parent.Right = node.Right;
                node.Right.Parent = node.Parent;
            }
            return true;
        }

        // all other cases (node with Left AND Right children).

        // actually perform the deletion:
        // find InOrderSuccessor or InOrderPredecessor node with respect to the node to be deleted
        // assign the value of InOrderSuccessor or InOrderPredecessor node to the node to be deleted
        // remove the InOrderSuccessor or InOrderPredecessor node. 
        // (in case we use a single recursive call the assignment before should happen after the recursive call)

        //First Option
        //Find successor node:

        // var successor = findInOrderSucc(node);
        // var successor_value = successor.Value;
        // DeleteValue(successor_value); //One recursive call 
        // node.Value = successor_value; //assignment after the recursive call

        // //Deletion steps instead of recursive call 
        // //Left and Right One step: (successor.Left == null -> true)
        // // if(isLeft(successor, successor.Parent)) {
        // //     successor.Parent.Left = successor.Right;
        // //     }
        // // else { //successor is first node right 
        // //     successor.Parent.Right = successor.Right;   
        // // }
        // // if(successor.Right != null)
        // //     successor.Right.Parent = successor.Parent;

        //Second Option
        //Find predecessor node:

        var predecessor = FindInOrderPredecessor(node);
        var predecessor_value = predecessor.Value;

        DeleteValue(predecessor_value); //One recursive call 
        node.Value = predecessor_value; //assignment after the recursive call

        //Deletion steps instead of recursive call 
        //Left and Right One step: (predecessor.Right == null -> true)

        // if(isLeft(predecessor, predecessor.Parent)) {
        //     predecessor.Parent.Left = predecessor.Left;
        // }
        // else { // predecessor is first node left (predecessor.Right == null)
        //     predecessor.Parent.Right =  predecessor.Left;   
        // }
        // if(predecessor.Left != null)
        // predecessor.Left.Parent = predecessor.Parent;


        return true;
    }

    private bool Remove(TreeNode<T>? node, T value) {
        if (node is null) {
            return false;
        }
        if (value.CompareTo(node.Value) == -1) {
            return Remove(node.Left, value);
        }
        if (value.CompareTo(node.Value) == 1) {
            return Remove(node.Right, value);
        }
        if (node.Left is null && node.Right is null) {
            node = null;
            return true;
        }
        if (node.Left is null && node.Right is not null) {
            TreeNode<T> temp = node.Right;
            temp.Parent = node.Parent;
            node = temp;
            return true;
        }
        if (node.Left is not null && node.Right is null) {
            TreeNode<T> temp = node.Left;
            temp.Parent = node.Parent;
            node = temp;
            return true;
        }

        TreeNode<T>? successor = FindInOrderSucc(node);
        node.Value = successor.Value;
        return Remove(node.Right, successor.Value);
    }

    private bool DeleteValue(BST<T>? tree, T value) => throw new NotImplementedException();

    private bool delete(TreeNode<T> nodeToDelete) {
        throw new NotImplementedException();
        // CASE 1 : LEAF

        // CASE 2 : ONE CHILD

        // CASE 3 : TWO CHILDREN

        // find inordersucc == smallest element of right subtree

        // copy value to nodeToDelete

        // call recursively delete on inordersucc 
    }

    // This methods finds the in order successor of the node given as parameter
    private TreeNode<T>? FindInOrderSucc(TreeNode<T> node) {
        var currNode = node.Right;
        while (currNode != null && currNode.Left != null)
            currNode = currNode.Left;

        return currNode;
    }

    private TreeNode<T>? FindInOrderPredecessor(TreeNode<T> node) {
        var currNode = node.Left;
        while (currNode != null && currNode.Right != null)
            currNode = currNode.Right;

        return currNode;
    }

    // This methods checks if the node given as first parameter is the left child of the node given as second parameter ("parent"). 
    // The comparison is based on the values of the nodes.
    private bool IsLeft(TreeNode<T> node, TreeNode<T> parent) {
        return parent.Left != null && parent.Left.Value.CompareTo(node.Value) == 0;
    }

    public List<T> Traversal(TraversalOrder traversalOrder) //Optional
    {
        throw new NotImplementedException();
    }

    #endregion
}