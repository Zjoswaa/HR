string color = askColor();
int number = askNumber();

int fortuneNumber = ((color.Length + number) % 4) + 1;
PrintFortune(fortuneNumber);

static void PrintFortune(int fortuneNumber) {
    string fortune = fortuneNumber switch {
        1 => "You will be loved and be happy!",
        2 => "You will be loved and be rich!",
        3 => "You will be loved and be famous!",
        4 => "You will be loved, and you'll be happy, rich and famous!",
        _ => "Unknown. :( But you will still be loved, no matter what."
    };
    Console.WriteLine(fortune);
}

static string askColor() {
    while(true) {
        Console.WriteLine("Pick a color (red/blue/green/yellow):");
        string input = Console.ReadLine();
        if (input == "red" || input == "blue" || input == "green" || input == "yellow") {
            return input;
        }
    }
}

static int askNumber() {
    while(true) {
        Console.WriteLine("Pick a number (1-8)");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int result)) {
            continue;
        }
        if (result > 0 && result < 9) {
            return result;
        }
    }
}
