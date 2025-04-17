using System.Diagnostics;
using Solution;

//For the sorted array [1, 3, 4, 6, 7, 8, 9, 11, 19] 
// with the key 6, the method should return 3,
// for key 5, the method should return -1 (since 5 is not present in the array).
int[] sorted_array = { 1, 3, 4, 6, 7, 8, 9, 11, 19 };
Console.WriteLine($"The sorted_array is {(Q1.IsSorted(sorted_array) == true ? "sorted" : "not sorted")}");

var index = Q1.SearchIndex(sorted_array, 6, Q1.IsSorted, Q1.OrderArray, Q1.Search);
Console.WriteLine($"The index of element 6 is {index}");

index = Q1.SearchIndex(sorted_array, 5, Q1.IsSorted, Q1.OrderArray, Q1.Search);
Console.WriteLine($"The index of element 5 is {index}");


//For the unsorted array [25, 15, 35, 9, 18, 50] with the key 9, the method should first sort and the return 0 
// (since 9 would be at 0 index after sorting).

int[] unsorted_array = { 25, 15, 35, 9, 18, 50 };
Console.WriteLine($"The unsorted_array is {(Q1.IsSorted(unsorted_array) == true ? "sorted" : "not sorted")}");
index = Q1.SearchIndex(unsorted_array, 9, Q1.IsSorted, Q1.OrderArray, Q1.Search);
Console.WriteLine($"The index of element 9 is {index}");

//Another input
int[] unsorted_array2 = { 15, 22, 3, 8, 77, 1, 7, 2 };
int[] array2 = { 15, 22, 3, 8, 77, 1, 7, 2 };
int[] sortedArray2 = { 1, 2, 3, 7, 8, 15, 22, 77 };
System.Console.WriteLine($"\nBefore sorting:\n{string.Join(" ", array2)}\n");
Q1.OrderArray(array2);
System.Console.WriteLine(
    $"After sorting:\n{string.Join(" ", array2)}\narray is sorted:{Q1.IsSorted(array2)}\n\nCorrectly Sorted:\n{string.Join(" ", sortedArray2)}");

Console.WriteLine(
    $"\nThe unsorted_array:\n{string.Join(" ", unsorted_array2)}\nis {(Q1.IsSorted(unsorted_array2) == true ? "sorted" : "not sorted")}");
index = Q1.SearchIndex(unsorted_array2, 3, Q1.IsSorted, Q1.OrderArray, Q1.Search);
Console.WriteLine($"\nThe index of element 3 is: {(index == 2 ? $"{index}, Correct!" : $"{index}, it should be 2")}");
