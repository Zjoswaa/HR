using ToDo;

var actualValue = new double[] { -3.3, 0.2, 10, 13.13, 13.19, -1, 0, 10.50 };
var expectedValue = new double[] { -3.3, -1, 0, 0.2, 10, 10.50, 13.13, 13.19 };
Sort<double>.MergeSort(actualValue, 0, actualValue.Length - 1);
var test = true;
for (int i = 0; test && i <= actualValue.Length - 1 && i <= expectedValue.Length - 1; ++i)
    test = actualValue[i].CompareTo(expectedValue[i]) == 0;

System.Console.WriteLine($"Correctly sorted: {(test ? "yes" : "no")}");
System.Console.WriteLine();
