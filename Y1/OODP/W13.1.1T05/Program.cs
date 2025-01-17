public class Program {
    static void Main() {
        var calcPriceTax10 = GetPriceCalculator(0.1);

        // Calculate the final price of multiple products
        // with the same tax rate
        double product1Discount = 0.2;
        double product1Price = 100.0;
        double product1FinalPrice = calcPriceTax10(product1Discount)(product1Price);

        double product2Discount = 0.1;
        double product2Price = 50.0;
        double product2FinalPrice = calcPriceTax10(product2Discount)(product2Price);

        // Calculate the final price of multiple products
        // with the same tax rate and discount
        var calcPriceTax10Discount30 = calcPriceTax10(0.3);
        double product3Price = 200.0;
        double product3FinalPrice = calcPriceTax10Discount30(product3Price);

        double product4Price = 150.0;
        double product4FinalPrice = calcPriceTax10Discount30(product4Price);


        Console.WriteLine($"Product 1 final price: {Math.Round(product1FinalPrice, 2)}");
        Console.WriteLine($"Product 2 final price: {Math.Round(product2FinalPrice, 2)}");
        Console.WriteLine($"Product 3 final price: {Math.Round(product3FinalPrice, 2)}");
        Console.WriteLine($"Product 4 final price: {Math.Round(product4FinalPrice, 2)}");
    }

    // GetPriceCalculator goes here
    static Func<double, Func<double, double>> GetPriceCalculator(double taxRate) {
        return discount => (price => price * (1 - discount) * (1 + taxRate));
    }
}
