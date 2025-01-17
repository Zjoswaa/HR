static class Program
{
    private static Random _random;

    public static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Abstract": TestAbstract(); return;
            case "CarsOnly": CarsOnly(); return;
            case "TrucksOnly": TrucksOnly(); return;
            case "Seed0": InitializeRandom(0); TestParking(); return;
            case "Seed1": InitializeRandom(1); TestParking(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestAbstract()
    {
        Type typeOfVehicle = typeof(Vehicle);
        Console.WriteLine("Class Vehicle is abstract: " +
            (typeOfVehicle.IsAbstract && !typeOfVehicle.IsInterface));
        Console.WriteLine("Property Size is abstract: " +
            typeOfVehicle.GetProperty("Size").GetMethod.IsAbstract);
    }

    public static void CarsOnly()
    {
        int[] rowCols = new int[] { 2, 4, 6 };
        ParkingLot parkingLot = new ParkingLot(rowCols);

        int numCars = 10;
        for (int i = 0; i < numCars; i++)
        {
            bool parked = ParkVehicle(parkingLot, new Car(), i + 1);
            if (!parked)
                continue;
        }

        Console.WriteLine($"Number of cars parked: {parkingLot.NumCarsParked()}");
    }

    public static void TrucksOnly()
    {
        int[] rowCols = new int[] { 2, 4, 6 };
        ParkingLot parkingLot = new ParkingLot(rowCols);

        int numTrucks = 10;
        for (int i = 0; i < numTrucks; i++)
        {
            bool parked = ParkVehicle(parkingLot, new Truck(), i + 1);
            if (!parked)
                continue;
        }

        Console.WriteLine($"Number of trucks parked: {parkingLot.NumTrucksParked()}");

    }

    public static void InitializeRandom(int seed) => _random = new(seed);

    public static void TestParking()
    {
        int[] rowCols = new int[] { 4, 4, 8 };
        ParkingLot parkingLot = new ParkingLot(rowCols);

        int numVehicles = 20;
        for (int i = 0; i < numVehicles; i++)
        {
            int size = _random.Next(1, 3); // 1 for car, 2 for truck
            Vehicle vehicle = size == 1 ? new Car() : new Truck();

            bool parked = ParkVehicle(parkingLot, vehicle, i + 1);
            if (!parked)
                continue;
        }

        Console.WriteLine($"Number of cars parked: {parkingLot.NumCarsParked()}");
        Console.WriteLine($"Number of trucks parked: {parkingLot.NumTrucksParked()}");
    }

    private static bool ParkVehicle(ParkingLot parkingLot, Vehicle vehicle, int vehicleNumber)
    {
        ParkingSpace space = parkingLot.FindAvailableSpace(vehicle);
        if (space == null)
        {
            Console.WriteLine($"Vehicle {vehicleNumber} could not find a parking space");
            return false;
        }

        parkingLot.ParkVehicle(vehicle, space);
        Console.WriteLine($"Vehicle {vehicleNumber} parked successfully at ({space.Row},{space.Col})");
        return true;
    }
}
