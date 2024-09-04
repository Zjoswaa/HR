int currentX = 0;
int currentY = 0;

Console.WriteLine("What direction would you like to go?\nUp\nDown\nRight\nLeft");
string input = Console.ReadLine();

if (input.ToUpper() == "UP") {
    currentY++;
} else if (input.ToUpper() == "DOWN") {
    currentY--;
} else if (input.ToUpper() == "LEFT") {
    currentX--;
} else if (input.ToUpper() == "RIGHT") {
    currentX++;
} else {
    Console.WriteLine("Invalid direction");
}
Console.WriteLine($"Current position\nX:{currentX}, Y:{currentY}");
