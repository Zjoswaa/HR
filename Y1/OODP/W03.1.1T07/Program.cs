class Program {
    public static void Main() {
        Car car = new Car();
        for (int i = 0; i < 10; i++)
            car.Drive();
        int mileage = car.Mileage;
        Console.WriteLine($"The car's mileage is {mileage}");
    }
}
