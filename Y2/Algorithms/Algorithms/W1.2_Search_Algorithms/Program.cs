using ToDo;

var rand = new Random();
int[] a = new int[100];
for (int idx = 0; idx < a.Length; idx++)
    a[idx] = rand.Next(-3000, 4000);
var randIndices = Enumerable.Range(0, a.Length).OrderBy(x => rand.Next()).ToArray();
int valueToSearch = a[randIndices[rand.Next(0, a.Length)]];

Array.Sort(a);

Utils.SetToZero();
var actualValue = BinarySearch.binarySearchRecursive(a, 0, a.Length - 1, valueToSearch);
System.Console.WriteLine(Utils.counter);
Utils.SetToZero();
