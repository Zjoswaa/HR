int currentX = 0;
int currentY = 0;

Console.WriteLine("What direction would you like to go?\nUp\nDown\nRight\nLeft");
string input = Console.ReadLine();

switch (input.ToUpper()) {
    case "UP":
        currentY++;
        break;
    case "DOWN":
        currentY--;
        break;
    case "LEFT":
        currentX--;
        break;
    case "RIGHT":
        currentX++;
        break;
}

Console.WriteLine($"Current position\nX:{currentX}, Y:{currentY}");
