Console.WriteLine("What is the temperature of the water? (Celsius)");
double celsius = double.Parse(Console.ReadLine());
if (celsius <= 0) {
    Console.WriteLine($"At {celsius} degrees Celsius, the water will be solid");
} else if (celsius >= 100) {
    Console.WriteLine($"At {celsius} degrees Celsius, the water will be gas");
} else {
    Console.WriteLine($"At {celsius} degrees Celsius, the water will be liquid");
}
