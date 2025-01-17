static class Program {
    static void Main() {
        List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        List<int> evenNums = HOF.Filter(nums, x => x % 2 == 0);
        Console.WriteLine(string.Join(",", evenNums)); // Output: 2,4,6,8

        List<int> numsGreaterThan4 = HOF.Filter(nums, x => x > 4);
        Console.WriteLine(string.Join(",", numsGreaterThan4)); // Output: 5,6,7,8,9

        List<string> words = new() { "Hello", "world!", "How", "are", "you", "doing?" };
        List<string> longerThan5 = HOF.Filter(words, s => s.Length > 5);
        Console.WriteLine(string.Join(",", longerThan5)); // Output: "world!,doing?"
    }
}
