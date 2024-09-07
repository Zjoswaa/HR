string DetermineSeason(int month, int day) {
    return month switch {
        12 => day >= 21 ? "Winter" : "Autumn",
        1 or 2 => "Winter",
        3 => day >= 21 ? "Spring" : "Winter",
        4 or 5 => "Spring",
        6 => day >= 21 ? "Summer" : "Spring",
        7 or 8 => "Summer",
        9 => day >= 21 ? "Autumn" : "Summer",
        10 or 11 => "Autumn",
        _ => "Winter"
    };
}

Console.WriteLine("What is the month? 1-12");
int month = int.Parse(Console.ReadLine());
Console.WriteLine("What is the day? 1-31");
int day = int.Parse(Console.ReadLine());
Console.WriteLine($"On {day}-{month} it is {DetermineSeason(month, day)}");
