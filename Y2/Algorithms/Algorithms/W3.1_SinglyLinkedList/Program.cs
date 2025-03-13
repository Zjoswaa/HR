using Solution;

SinglyLinkedList<int> intList = new SinglyLinkedList<int>();

if (intList != null) {
    intList.AddSorted(20);
    intList.AddSorted(40);
    intList.AddSorted(30);
    intList.AddSorted(10);
    foreach (var el in intList) {
        System.Console.WriteLine(el);
    }
    int[] actual = new int[] {
        intList.Head.Value, intList.Head.Next.Value, intList.Head.Next.Next.Value, intList.Head.Next.Next.Next.Value
    };
    int[] expected = new int[] { 10, 20, 30, 40 };
}
