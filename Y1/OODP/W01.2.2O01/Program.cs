class Program() {
    static void Main() {
        Console.WriteLine("What is the amount to pay?");
        int totalPay = int.Parse(Console.ReadLine());
        int toPay = totalPay;

        while (toPay > 0) {
            Console.WriteLine($"{toPay} left to pay");
            switch (askInput()) {
                case 1:
                    toPay -= 5;
                    break;
                case 2:
                    toPay -= 10;
                    break;
                case 3:
                    toPay -= 20;
                    break;
                case 4:
                    toPay -= 50;
                    break;
                default: // This will never be reached though
                    break;
            }
        }
        // User paid too much after the while loop, ask if they want to tip the excess.
        if (toPay < 0) {
            if (askTip(toPay, totalPay)) {
                Console.WriteLine($"You have paid {totalPay + (toPay * -1)}");
            } else {
                Console.WriteLine($"You have paid {totalPay}");
            }
        }
    }

    static int askInput() {
        while (true) {
            Console.WriteLine("Pay how much?");
            Console.WriteLine("1: 5");
            Console.WriteLine("2: 10");
            Console.WriteLine("3: 20");
            Console.WriteLine("4: 50");
            string input = Console.ReadLine();

            switch (input) {
                case "1":
                case "2":
                case "3":
                case "4":
                    return int.Parse(input);
                default:
                    break;
            }
        }
    }

    static bool askTip(int toPay, int totalPay) {
        Console.WriteLine($"You paid {toPay * -1} too much. Give a tip? y/n");
        while (true) {
            string input = Console.ReadLine().ToUpper();
            switch (input) {
                case "Y":
                    return true;
                case "N":
                    return false;
                default:
                    break;
            }
        }
    }
}
