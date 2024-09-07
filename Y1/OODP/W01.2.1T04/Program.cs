bool correctPin = false;

for (int i = 3; i > 0; i--) {
    Console.WriteLine("Enter your PIN");
    Console.WriteLine($"{i} attempts left");
    if (Console.ReadLine() == "1234") {
        correctPin = true;
        break;
    }
}

if (!correctPin) {
    Console.WriteLine("Your pass is confiscated.");
} else {
    Console.WriteLine("Correct!");
}
