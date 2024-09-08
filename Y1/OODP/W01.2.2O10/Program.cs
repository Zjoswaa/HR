Random rand = new(0);
int min = 0;
int max = 0;
int answer = 0;
bool guessed = false;

Console.WriteLine("Time to play Guess The Number!");
do {
    Console.WriteLine("Give the minimum number: ");
    min = int.Parse(Console.ReadLine());
    Console.WriteLine("Give the maximum number: ");
    max = int.Parse(Console.ReadLine());
    if (min == max) {
        Console.WriteLine("The minimum and maximum are equal. Incrementing the maximum by 1.");
        max++;
    } else if (min > max) {
        Console.WriteLine("The minimum is higher than the maximum. Switching values.");
        (min, max) = (max, min); // Swap variables
    }

    answer = rand.Next(min, max + 1);
    guessed = false;

    while (!guessed) {
        Console.WriteLine($"Guess the number [{min}-{max}]");
        int input = int.Parse(Console.ReadLine());
        if (input == answer) {
            Console.WriteLine($"{input} is correct!");
            guessed = true;
        } else if (answer < input) {
            Console.WriteLine("Lower!");
        } else {
            Console.WriteLine("Higher!");
        }
    }

    Console.WriteLine("Do you wish to play another round? Y to continue");
} while (Console.ReadLine().ToUpper() == "Y");

Console.WriteLine("Thank you for playing!");
