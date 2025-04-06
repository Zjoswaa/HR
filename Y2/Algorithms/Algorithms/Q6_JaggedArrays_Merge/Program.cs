
using Solution;
// Test Merge third with second row
// Test Merge and Flatten all 

var intJaggedArray = new int[][]{
    null, 
    new int[] {2, 8, 25, 98} ,
    new int[] {7, 81, 120},
    new int[] {-23, 1, 3},
    new int[] {-4, 5, 6, 85},
    new int[] {},
};

var doubleJaggedArray = new double[][]{
    null, 
    new double[] {2, 8, 25.65, 98} ,
    new double[] {6.1, 81.2, 120},
    new double[] {-23, 1, 3, 81.199},
    new double[] {-4.5, 5, 6.75, 85},
    new double[] {},
};

var stringJaggedArray = new string[][]{
    null, 
    new string[] {"2", "8", "9", "hello"} ,
    new string[] {"7", "81"},
    new string[] {"0", "3"},
    new string[] {},
    new string[] {"4", "5", "6", "85"},
};

var one = new int[] {4, 7, 9, 11, 13, 21, 15};
var two = new int[] {6, 8, 12, 14, 20};
Console.WriteLine("\nArray \"one\": ");
Exam.Helper.Display(one);
Console.WriteLine("\nArray \"two\": ");
Exam.Helper.Display(two);
var intMerge = Q6.Merge(one, two);
System.Console.WriteLine("\nMerge array \"one\" with \"two\":");
Exam.Helper.Display(intMerge);

System.Console.WriteLine("Input: string jagged array\n");
Exam.Helper.Display(stringJaggedArray);
var stringMerge_2_1 = Q6.Merge(stringJaggedArray[2], stringJaggedArray[1]);
System.Console.WriteLine("\nMerge third with second row:");
Exam.Helper.Display(stringMerge_2_1);
var stringFlattenResult = Q6.Flatten(stringJaggedArray, Q6.Merge);
System.Console.WriteLine("\nMerge and Flatten of given input:");
Exam.Helper.Display(stringFlattenResult); 

System.Console.WriteLine("\nInput: int jagged array\n");
Exam.Helper.Display(intJaggedArray);
var intMerge_2_1 = Q6.Merge(intJaggedArray[2], intJaggedArray[1]);
System.Console.WriteLine("\nMerge third with second row:");
Exam.Helper.Display(intMerge_2_1);
var intFlattenResult = Q6.Flatten(intJaggedArray, Q6.Merge);
System.Console.WriteLine("\nMerge and Flatten of given input:");
Exam.Helper.Display(intFlattenResult); 
System.Console.WriteLine();

System.Console.WriteLine("\nInput: double jagged array\n");
Exam.Helper.Display(doubleJaggedArray);
var doubleMerge_2_1 = Q6.Merge(doubleJaggedArray[2], doubleJaggedArray[1]);
System.Console.WriteLine("\nMerge third with second row:");
Exam.Helper.Display(doubleMerge_2_1);
var doubleFlattenResult = Q6.Flatten(doubleJaggedArray, Q6.Merge);
System.Console.WriteLine("\nMerge and Flatten of given input:");
Exam.Helper.Display(doubleFlattenResult); 
System.Console.WriteLine();

System.Console.WriteLine();
