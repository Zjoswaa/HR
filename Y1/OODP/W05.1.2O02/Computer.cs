class Computer : Electronics {
    public Computer(string Name, double Price, int Stock, string Brand, string Model) : base(Name, Price, Stock, Brand, Model) { }

    public override void Sell(int Units) {
        base.Sell(Units);
        OfferAssistance();
    }

    private static void OfferAssistance() {
        Console.WriteLine("Call for installation help: 1234HELPME");
    }
}
