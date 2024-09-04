Console.WriteLine("What is the month? 1-12");
int month = int.Parse(Console.ReadLine());
Console.WriteLine("What is the day? 1-31");
int day = int.Parse(Console.ReadLine());

if ((month == 12 && day >= 21) || (month == 1) || (month == 2) || (month == 3 && day < 21)) {
    Console.WriteLine($"On {day}-{month} it is Winter");
}
else if ((month == 3 && day >= 21) || (month == 4) || (month == 5) || (month == 6 && day < 21)) {
    Console.WriteLine($"On {day}-{month} it is Spring");
}
else if ((month == 6 && day >= 21) || (month == 7) || (month == 8) || (month == 9 && day < 21)) {
    Console.WriteLine($"On {day}-{month} it is Summer");
}
else {
    Console.WriteLine($"On {day}-{month} it is Autumn");
}
