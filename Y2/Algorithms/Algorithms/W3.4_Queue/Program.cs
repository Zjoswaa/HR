List<string?> aList = new List<string?>();
IQueue<string?> q = new Solution.Queue<string?>(3);

q.Enqueue("Alpha");
q.Enqueue("Bravo");
aList.Add(q.Dequeue());
q.Enqueue("Charlie");
q.Enqueue("Delta");
aList.Add(q.Dequeue());
aList.Add(q.Dequeue());
aList.Add(q.Dequeue());
aList.Add(q.Dequeue());

foreach (var el in aList) {
    System.Console.WriteLine(el);
}
