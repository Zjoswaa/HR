Console.WriteLine("What is the temperature in Celsius?");
double celsius = double.Parse(Console.ReadLine());
Console.WriteLine($"{celsius} C = {celsius * 1.8 + 32.0} F");
Console.WriteLine($"Truncated that is {(int)(celsius * 1.8 + 32.0)} F");
