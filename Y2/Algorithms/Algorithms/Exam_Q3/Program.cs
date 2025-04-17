using Solution;


BST<int> bst = new BST<int>();

var BFTArray = bst.BFT();

System.Console.WriteLine(BFTArray == null); //no elements in the BST

int[] intArray = [8, 3, 10, 1, 6, 14, 4, 7, 13]; 

  /*

          8
        /   \
       3     10
      / \      \
     1   6      14
        / \     /
       4   7  13 
   
*/

string printTree = @$"

          8
        /   \
       3     10
      / \      \
     1   6      14
        / \    /
       4   7  13
        
       ";


//Creating a BST without using an Insert method
var root = new TreeNode<int>(intArray[0]);
var leftNode = new TreeNode<int>(intArray[1]);
var rightNode = new TreeNode<int>(intArray[2]);
root.Left = leftNode;
root.Right = rightNode;
leftNode.Left = new TreeNode<int>(intArray[3]);
leftNode.Right = new TreeNode<int>(intArray[4]);

rightNode.Right = new TreeNode<int>(intArray[5]);

leftNode.Right.Left = new TreeNode<int>(intArray[6]);
leftNode.Right.Right = new TreeNode<int>(intArray[7]);

rightNode.Right.Left = new TreeNode<int>(intArray[8]);

bst.Root = root;

var bftList = bst.BFT();
System.Console.WriteLine(printTree + "\n");
bftList!.ToList().ForEach(_ => System.Console.Write($"({_}); ") );

System.Console.WriteLine();

BST<string> bst_ = new BST<string>();

string[] stringArray = ["8", "3", "10", "2", "6", "14", "4", "7", "12"]; 

  /*

          8
        /   \
       3     10
      / \      \
     2   6      14
        / \     /
       4   7  12 
   
*/

string printTree_ = @$"

          8
        /   \
       3     10
      / \      \
     2   6      14
        / \    /
       4   7  12
        
       ";


//Creating a BST without using an Insert method
var root_ = new TreeNode<string>(stringArray[0]);
var leftNode_ = new TreeNode<string>(stringArray[1]);
var rightNode_= new TreeNode<string>(stringArray[2]);
root_.Left = leftNode_;
root_.Right = rightNode_;
leftNode_.Left = new TreeNode<string>(stringArray[3]);
leftNode_.Right = new TreeNode<string>(stringArray[4]);

rightNode_.Right = new TreeNode<string>(stringArray[5]);

leftNode_.Right.Left = new TreeNode<string>(stringArray[6]);
leftNode_.Right.Right = new TreeNode<string>(stringArray[7]);

rightNode_.Right.Left = new TreeNode<string>(stringArray[8]);

bst_.Root = root_;

var bftList_ = bst_.BFT();
System.Console.WriteLine("\n" + printTree_ + "\n");
bftList_!.ToList().ForEach(_ => System.Console.Write($"[{_}]: ") );
System.Console.WriteLine();
