using Solution;

var n1 = new DoubleNode<int>(5, null, null);
var n2 = new DoubleNode<int>(-3, null, n1);
var n3 = new DoubleNode<int>(2, null, n2);
var n4 = new DoubleNode<int>(-3, null, n3);
var n5 = new DoubleNode<int>(4, null, n4);
n1.Next = n2;
n2.Next = n3;
n3.Next = n4;
n4.Next = n5;

DoublyLinkedList<int> dl = new DoublyLinkedList<int>();
dl.First = n1;
dl.Last = n5;

System.Console.WriteLine("Double Linked List:");
foreach (var el in dl)
    System.Console.WriteLine(el);

int[] actual = new int[] {
    dl.First.Value,
    dl.First.Next.Value,
    dl.First.Next.Next.Value,
    dl.First.Next.Next.Next.Value,
    dl.First.Next.Next.Next.Next.Value
};

System.Console.WriteLine("\nFirst -> Last:");
foreach (var el in actual)
    System.Console.WriteLine(el);

actual = new int[] {
    dl.Last.Value,
    dl.Last.Previous.Value,
    dl.Last.Previous.Previous.Value,
    dl.Last.Previous.Previous.Previous.Value,
    dl.Last.Previous.Previous.Previous.Previous.Value,
};

System.Console.WriteLine("\nLast -> First:");
foreach (var el in actual)
    System.Console.WriteLine(el);

System.Console.WriteLine();
