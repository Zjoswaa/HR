class Program {
    public static void Main() {
        Console.WriteLine("What is the limit for the amount of cars?");
        int limit = Convert.ToInt32(Console.ReadLine());
        var factory = new CarFactory(limit);

        var carList = new List<LimitedEditionCar>();
        for (int i = 0; i < 10; i++)
            carList.Add(factory.ProduceLimitedEditionCar());

        Console.WriteLine($"Limited edition cars produced: {LimitedEditionCar.Counter}");

        foreach (var car in carList) {
            if (car != null)
                Console.WriteLine(car.ChassisNumber);
            else
                Console.WriteLine("Not allowed to produce more");
        }
    }
}
