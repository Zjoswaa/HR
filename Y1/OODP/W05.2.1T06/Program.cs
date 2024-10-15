public class Program {
    public static void Main() {
        House house = new(75, 4);
        Console.WriteLine(house.Info);
        Console.WriteLine(house.SquareMeters);
        Console.WriteLine(house.Price);
        house.HomeImprovement();
        Console.WriteLine(house.Info);
        Console.WriteLine(house.SquareMeters);
        Console.WriteLine(house.Price);

        VacationHouse vacationHouse = new(50, 3);
        Console.WriteLine(vacationHouse.Info);
        Console.WriteLine(vacationHouse.SquareMeters);
        Console.WriteLine(vacationHouse.Price);
        vacationHouse.HomeImprovement();
        Console.WriteLine(vacationHouse.Info);
        Console.WriteLine(vacationHouse.SquareMeters);
        Console.WriteLine(vacationHouse.Price);
    }
}
