public class Program {
    public static void Main(string[] args) {
        string[] inputStrArr = args[1..^0];
        //Input strings for first test:
        //"racecar", "hello", "level", "A man, a plan, a canal, Panama!";

        foreach (string str in inputStrArr) {
            //Make lowercase and remove non-letters
            string cleanedStr = new string(str.ToLower().Where(c => char.IsLetter(c)).ToArray());

            bool isPalindrome = IsPalindrome(cleanedStr);
            Console.WriteLine($"\"{cleanedStr}\" is {(isPalindrome ? "a palindrome" : "not a palindrome")}");
        }
    }

    static bool IsPalindrome(string s) {
        if (s.Length <= 1) {
            return true;
        }

        if (s[0] != s[^1]) {
            return false;
        }

        return IsPalindrome(s.Substring(1, s.Length - 2));
    }
}
