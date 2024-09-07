Console.WriteLine("You have one chance to guess this six-letter word:");
Console.WriteLine("Le..th");
string input = Console.ReadLine();

if (input == "Length") {
    Console.WriteLine("Correct!");
} else if (input.ToLower() == "length") {
    Console.WriteLine("Kind of correct; the case was just wrong");
} else if (input.Length != 6) {
    Console.WriteLine("Incorrect! That is not even a six-letter word!");
} else {
    Console.WriteLine("Incorrect");
}
