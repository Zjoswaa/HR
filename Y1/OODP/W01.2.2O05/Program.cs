static double calculateTaxes(double balance) {
    double taxableBalance = Math.Max(0, balance - 50000);
    double taxes = 0;

    if (taxableBalance > 50_000) {
        taxes += (taxableBalance - 50_000) * 0.03;
        taxableBalance = 50_000;
    }
    if (taxableBalance > 0) {
        taxes += taxableBalance * 0.015;
    }

    return taxes;
}

double taxesPaid = 0;
Console.Write("Initial balance: ");
double balance = int.Parse(Console.ReadLine());
Console.Write("Interest rate: ");
double interestRate = (double)int.Parse(Console.ReadLine()) / 100.0;
Console.Write("Years: ");
int years = int.Parse(Console.ReadLine());

for (int i = 0; i < years; i++) {
    balance += balance * interestRate;
    double thisYearTax = calculateTaxes(balance);
    balance -= thisYearTax;
    taxesPaid += thisYearTax;
}

Console.WriteLine($"Balance after {years} years: {(int)balance}");
Console.WriteLine($"Amount of taxes paid: {(int)taxesPaid}");
