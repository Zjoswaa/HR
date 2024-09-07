Console.WriteLine("What is the persons name?");
string name = Console.ReadLine();

for (int i = 0; i < 4; i++) {
    if (i == 2) {
        Console.WriteLine($"Happy birthday dear {name}!");
    }
    else {
        Console.WriteLine("Happy birthday to you!");
    }
}
