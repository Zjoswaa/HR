Console.Write("First number: ");
int start = int.Parse(Console.ReadLine());
Console.Write("Second number: ");
int end = int.Parse(Console.ReadLine());

for (int i = start; i <= end; ++i) {
    if (i % 5 == 0 && i % 3 == 0) {
        Console.WriteLine("FizzBuzz");
    } else if (i % 3 == 0) {
        Console.WriteLine("Fizz");
    } else if (i % 5 == 0) {
        Console.WriteLine("Buzz");
    } else {
        Console.WriteLine(i);
    }
}
