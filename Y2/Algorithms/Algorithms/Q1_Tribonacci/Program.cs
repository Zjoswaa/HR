using Solution;

long n = 2;
Utils.SetToZero();
var actual = Q1.Tribonacci(n, null);
var actualCalls = Utils.counter;
System.Console.WriteLine($"Tribonacci({n}) = {actual}, recursive calls: {actualCalls}\n");

n = 6;
Utils.SetToZero();
actual = Q1.Tribonacci(n, null);
actualCalls = Utils.counter;
System.Console.WriteLine($"Tribonacci({n}) = {actual}, recursive calls: {actualCalls}\n");

var rand = new Random();
n = rand.Next(10, 15);
//Uncommenting the following and calling a not properly memoized version 
//of the method "Tribonacci" will take a long time.
//n = rand.Next(50, 65); 
long[] intermediateResultsActual = new long[n + 1];
// initialize the first three values in the array which we use as a map
intermediateResultsActual[0] = 0;
intermediateResultsActual[1] = 0;
intermediateResultsActual[2] = 1;

Utils.SetToZero();
actual = Q1.Tribonacci(n, intermediateResultsActual);
actualCalls = Utils.counter;

System.Console.WriteLine($"Tribonacci({n}) = {actual}, recursive calls: {actualCalls}\n");
System.Console.WriteLine("Intermediate results:");

var totalValues = intermediateResultsActual.ToList().Count(x => x != 0) + 2;
intermediateResultsActual.Take(totalValues).ToList().ForEach(System.Console.WriteLine);
System.Console.WriteLine();
