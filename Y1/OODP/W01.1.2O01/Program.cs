Console.WriteLine("How many seconds?");
int secondsTotal = int.Parse(Console.ReadLine());
int hours = secondsTotal / 3600;
int minutesLeft = secondsTotal / 60 - (hours * 60);
int secondsLeft = secondsTotal - (hours * 3600) - (minutesLeft * 60);

Console.WriteLine($"Hours: {hours}\nMinutes: {minutesLeft}\nSeconds left: {secondsLeft}");
