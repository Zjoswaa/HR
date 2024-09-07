int money = 4;

while (money > 0) {
    Console.WriteLine($"Money left: {money}");
    Console.WriteLine("Look around (1) or go in a ride (2)?");
    int input = int.Parse(Console.ReadLine());
    switch (input) {
        case 1:
            Console.WriteLine("Yay!");
            break;
        case 2:
            money--;
            Console.WriteLine("Wheee!");
            break;
    }
}
Console.WriteLine("Time to go home");
