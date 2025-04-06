using Solution;

//using ToDo;

Console.WriteLine("Delete Node\n\n");
BST<int> bst = new BST<int>();
bst.Insert(50);
bst.Insert(30);
bst.Insert(10);
bst.Insert(20);
bst.Insert(40);
bst.Insert(75);
bst.Insert(65);
bst.Insert(55);
bst.Insert(95);
bst.Insert(90);
bst.Insert(15);
bst.Insert(60);
/* Drawing above bst
                        50
        30/                             \75
10/             \40             65/                 \95
    \20                     55/                 90/
    15/                           \60
*/
Console.WriteLine("\nTree (PreOrder Traversal):");
Console.WriteLine(String.Join(" : ", bst.Traversal(TraversalOrder.PreOrder)));
Console.WriteLine("\nTree (InOrder Traversal):");
Console.WriteLine(String.Join(" : ", bst.Traversal(TraversalOrder.InOrder)));
var ltd = new int[] { 37, 30, 87, 75, 50, 50, 65, 55, 95, 15, 10, 40 };
foreach (var item in ltd) {
    var node = bst.Search(bst.Root, item);
    Console.WriteLine(
        $"\nSearch value: {item} => {(node == null ? $"value: {item} <NOT FOUND>" : $"value: {item} FOUND")}");
    if (bst.Contains(item)) {
        Console.WriteLine($"Delete value: {item} => {bst.Remove(node.Value)}");
        Console.WriteLine(
            $"Search value: {item} => {(bst.Search(bst.Root, item) == null ? $"value: {item} <NOT FOUND>" : $"value: {item} FOUND")}");
    }
    Console.WriteLine("InOrder: " + String.Join(" : ", bst.Traversal(TraversalOrder.InOrder)));
}

Console.WriteLine();
