void drawCompass(bool[] directions) {
    if (directions[0]) {
        Console.WriteLine("    N    ");
        Console.WriteLine("    |    ");
    } if (directions[3]) {
        Console.Write("W---");
    } else {
        Console.Write("    ");
    }
    Console.Write("|");
    if (directions[1]) {
        Console.WriteLine("---E");
    } else {
        Console.WriteLine("    ");
    }
    if (directions[2]) {
        Console.WriteLine("    |    ");
        Console.WriteLine("    S    ");
    }
}

bool[] directions = { false, false, false, false }; // North, East, South, West

Console.WriteLine("For each direction, input Y/N if it is valid.");
Console.WriteLine("North? Y/N");
if (Console.ReadLine().ToUpper() == "Y") {
    directions[0] = true;
}
Console.WriteLine("East? Y/N");
if (Console.ReadLine().ToUpper() == "Y") {
    directions[1] = true;
}
Console.WriteLine("South? Y/N");
if (Console.ReadLine().ToUpper() == "Y") {
    directions[2] = true;
}
Console.WriteLine("West? Y/N");
if (Console.ReadLine().ToUpper() == "Y") {
    directions[3] = true;
}
Console.WriteLine("Give a bearing (a number) for the direction in which you are going.");
int direction = int.Parse(Console.ReadLine()) % 360;
if (direction < 0) {
    direction += 360;
}

Console.WriteLine("From here you can go");
drawCompass(directions);

if (direction > 315 || direction <= 45) {
    if (directions[0]) {
        Console.WriteLine("You are going north");
    } else {
        Console.WriteLine("You can't go north");
    }
} else if (direction > 45 && direction <= 135) {
    if (directions[1]) {
        Console.WriteLine("You are going east");
    } else {
        Console.WriteLine("You can't go east");
    }
} else if (direction > 135 && direction <= 225) {
    if (directions[2]) {
        Console.WriteLine("You are going south");
    } else {
        Console.WriteLine("You can't go south");
    }
} else if (direction > 225 || direction <= 135) {
    if (directions[3]) {
        Console.WriteLine("You are going west");
    } else {
        Console.WriteLine("You can't go west");
    }
}
