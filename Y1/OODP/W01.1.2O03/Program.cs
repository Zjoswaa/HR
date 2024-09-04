int points = 0;

Console.WriteLine("Answer the following MCQs:");
Console.WriteLine("Which of the following is NOT a valid type in C#?");
Console.WriteLine("A: bool");
Console.WriteLine("B: int");
Console.WriteLine("C: var");
Console.WriteLine("D: string");
if (Console.ReadLine().ToUpper() == "C") {
    points++;
}

Console.WriteLine("\nWhat happens if you execute the following line C#?\nint x = 1.23;");
Console.WriteLine("A: x will be 1.23");
Console.WriteLine("B: x will be 1");
Console.WriteLine("C: x will be 1.0");
Console.WriteLine("D: you will get a compiler error");
if (Console.ReadLine().ToUpper() == "D") {
    points++;
}

double d = 1.23;

Console.WriteLine("\nConsider the following line:\ndouble d = 1.23;\nWhat are TWO ways to convert variable d to an int?");
Console.WriteLine("A: int i = (int)d;");
Console.WriteLine("B: int i = int(d)");
Console.WriteLine("C: int i = 0 + d");
Console.WriteLine("D: int i = Convert.ToInt32(d)");

Console.WriteLine("Your first answer:");
string first = Console.ReadLine();
Console.WriteLine("Your second answer:");
string second = Console.ReadLine();
if ((first.ToUpper() == "A" && second.ToUpper() == "D") || (first.ToUpper() == "D" && second.ToUpper() == "A")) {
    points++;
}
if (points == 3) {
    Console.WriteLine($"Your score: 3 out of 3. Well done!");
} else {
    Console.WriteLine($"Your score: {points} out of 3.");
}
