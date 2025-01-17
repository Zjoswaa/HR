static class Program {
    static void Main() {
        int[] myArray = { 1, 3, 5, 7, 9 };
        Console.Write("Give a number to search for: ");
        int targetValue = Convert.ToInt32(Console.ReadLine());
        int index = RecSearch.BinarySearch(myArray, targetValue);

        if (index != -1) {
            Console.WriteLine($"Found {targetValue} at index {index}");
        }
        else {
            Console.WriteLine($"{targetValue} was not found in the array");
        }
    }
}
