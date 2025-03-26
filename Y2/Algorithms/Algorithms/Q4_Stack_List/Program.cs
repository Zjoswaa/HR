using Solution;

var stk = new StackLL<string>();
for (int i = 1; i <= 10; ++i) {
    if (i % 3 == 0)
        Console.WriteLine(
            $"Peek() => {(stk.Peek() == null ? "<NULL>" : stk.Peek())}, after Peek -> Count: {stk.Count}");
    stk.Push(i + "");
    Console.WriteLine($"Push({i}); after Push -> Count: {stk.Count} ");
    if (i % 5 == 0) {
        var val = stk.Pop();
        Console.WriteLine($"Pop() => {(val == null ? "<NULL>" : val)}, after Pop -> Count: {stk.Count}");
    }
}
System.Console.WriteLine($"Pop() until Count is 0, Now -> Count: {stk.Count}");
var idx = 1;
while (stk.Count > 0) {
    var val = stk.Pop();
    Console.WriteLine($"{idx++}) Pop() => {(val == null ? "<NULL>" : val)}, after Pop -> Count: {stk.Count}");
}
System.Console.WriteLine($"----- Stack Count: {stk.Count}  -----");
var res = stk.Pop();
Console.WriteLine($"Pop() => {(res == null ? "<NULL>" : res)}, after Pop -> Count: {stk.Count}");
res = stk.Peek();
Console.WriteLine($"Peek() => {(res == null ? "<NULL>" : res)}, after Peek -> Count: {stk.Count}");
System.Console.WriteLine();
