public class Program {
    public static void Main() {
        Car car = new();
        Office office = new();
        Console.WriteLine(car.Info);
        Console.WriteLine(office.Info);
        car.Drive();
        office.Use();
        Console.WriteLine(car.Info);
        Console.WriteLine(office.Info);

        car.Drive();
        office.Use();
        CleaningService.Clean(new List<ICleanable>() { car, office });
        Console.WriteLine(car.Info);
        Console.WriteLine(office.Info);
    }
}
