int[] numbers = new int[] {
    -32, 2, 49, 46, -33, 3, 17, 64, -13, -4, -79, 89, 20, -61, -64, -34, -86, -82, 51, -35, 31, 13, 18, -72, -20, 42,
    77, 4, -88, -28, 1, -70, 99, -22, 93, 24, -65, 60, -15, 0, -59, 6, -80, 48, 98, 16, 80, -71, 45, 33, -9, -30, -89,
    -26, 27, -55, 69, -95, -31, -2, 75, 41, -46, 72, -44, -68, -50, 59, 39, -60, 22, 26, -58, -87, -14, 38, 83
};


Console.WriteLine("Divisble by 2:");
// int [] sorted = numbers.Order().ToArray();
foreach (int n in from num in numbers where num % 2 == 0 orderby num select num) {
    Console.WriteLine(n);
}

Console.WriteLine();
Console.WriteLine("Divisble by 2 and positive:");
foreach (int n in from num in numbers where (num % 2 == 0 && num > 0) orderby num descending select num) {
    Console.WriteLine(n);
}
