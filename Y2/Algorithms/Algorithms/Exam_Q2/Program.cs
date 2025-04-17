using Solution;

Random random = new Random();

var randomFirstValue = random.Next(40, 100);
var randomThirdValue = random.Next(500, 1000);

ListNode<int> firstNode = new ListNode<int>(randomFirstValue, null);
ListNode<int> thirdNode = new ListNode<int>(randomThirdValue, null);
firstNode.Tail = thirdNode;

// Node(first, Node(second, null))
MySinglyLinkedList<int> list = new MySinglyLinkedList<int>(firstNode);

int[] randomNumbers = Enumerable.Range(1, 10).Select(_ => random.Next(10, 30)).ToArray();

foreach (var number in randomNumbers) {
    list.AddAfter(number, firstNode);
}

var actual = list.Display();
var expected = randomFirstValue + ", " + string.Join(", ", randomNumbers.Reverse()) + ", " + randomThirdValue;
System.Console.WriteLine(actual);
System.Console.WriteLine(expected);

MySinglyLinkedList<string> list_ = new MySinglyLinkedList<string>();
var items = Enumerable.Range(1, 100).Select(_ => random.Next(1, 20)).Select(_ => (char)(_ + 'A') + "").Distinct()
    .ToArray();
list_.AddSortedRange(items, list_.AddAfter);

var actual_ = list_.Display();
var expected_ = string.Join(", ", items.OrderBy(_ => _));
System.Console.WriteLine(actual_);
System.Console.WriteLine(expected_);

System.Console.WriteLine();
