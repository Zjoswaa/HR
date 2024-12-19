public class Program {
    static void Main() {
        MyCollection collection = new(5);

        // Set values using square brackets
        collection[0] = 10;
        collection[1] = 20;
        collection[2] = 30;
        collection[3] = 40;
        collection[4] = 50;

        // Retrieve values using square brackets
        Console.WriteLine(collection[0]); // Output: 10
        Console.WriteLine(collection[3]); // Output: 40
    }
}
