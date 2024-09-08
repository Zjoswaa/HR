static int askNumber() {
    while (true) {
        Console.Write("Size: ");
        if (!int.TryParse(Console.ReadLine(), out int result)) {
            continue;
        }
        return Math.Clamp(result, 2, 9);
    }
}

int number = askNumber();

Console.Write("  |");
for (int i = 1; i <= number; i++) {
    Console.Write($"{i,4}");
}
Console.WriteLine();
for (int i = 0; i < number * 4 + 4; i++) {
    Console.Write("-");
}
Console.WriteLine();

for (int i = 1; i <= number; i++) {
    Console.Write($"{i} |");
    for (int j = 1; j <= number; j++) {
        Console.Write($"{i * j,4}");
    }
    Console.WriteLine();
}
