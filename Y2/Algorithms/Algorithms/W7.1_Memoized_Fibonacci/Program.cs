using Solution;

var rand = new Random();
long[] intermediateResultsActual = new long[100];
// initialize the first two values in the array which we use as a map
intermediateResultsActual[0] = 0;
intermediateResultsActual[1] = 1;

long n = rand.Next(8, 25);
//Uncommenting the following and calling a not properly memoized version 
//of the method "FibonacciDynamic" will take a long time.
//long n = rand.Next(50, 65); 

var actual = DynamicProgramming.FibonacciDynamic(n, intermediateResultsActual);
var actualCalls = Utils.counter;

System.Console.WriteLine($"Fibonacci({n}) = {actual}, recursive calls: {actualCalls})");
System.Console.WriteLine("Intermediate results:");

var totalValues = intermediateResultsActual.ToList().Count(x => x != 0) + 1;
intermediateResultsActual.Take(totalValues).ToList().ForEach(System.Console.WriteLine);
