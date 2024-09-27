using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Static": TestStatic(); return;
            case "ReadOnly": TestReadOnly(); return;
            case "FunctRace": TestFunctionalityRace(); return;
            case "FunctRunSeason": TestFunctionalitySeason(); return;
            case "FunctPrintResults": TestFunctionalitySeason(true); return;
            default: throw new ArgumentException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestStatic() {
        for (int i = 0; i < Season.PointsForPositions.Count; i++) {
            Console.WriteLine($"Points for position {i + 1}: {Season.PointsForPositions[i]}");
        }
    }

    public static void TestReadOnly() {
        Type clsType = typeof(Season);
        PrintIsFieldReadOnly(clsType, "Year");
        PrintIsFieldReadOnly(clsType, "Races");
        PrintIsFieldReadOnly(clsType, "Teams");
        PrintIsFieldReadOnly(clsType, "PointsForPositions");

        clsType = typeof(Race);
        PrintIsFieldReadOnly(clsType, "Location");

        clsType = typeof(Team);
        PrintIsFieldReadOnly(clsType, "Name");
        PrintIsFieldReadOnly(clsType, "Drivers");

        clsType = typeof(Driver);
        PrintIsFieldReadOnly(clsType, "Name");
    }

    public static void TestFunctionalityRace() {
        List<Driver> driversFromFirstToLast1 = Race.GetRaceResults(GetDrivers());
        List<Driver> driversFromFirstToLast2 = Race.GetRaceResults(GetDrivers());
        List<Driver> driversFromFirstToLast3 = Race.GetRaceResults(GetDrivers());

        if (AreDriverListsInSameOrder(
            driversFromFirstToLast1,
            driversFromFirstToLast2,
            driversFromFirstToLast3)) {
            Console.WriteLine("Race results are NOT randomized");
        } else {
            Console.WriteLine("Race results are randomized");
        }
    }

    public static void TestFunctionalitySeason(bool alsoPrintResults = false) {
        var races = AssembleRaces2022();
        var teams = AssembleTeams2022();

        Season season2022 = new(2022, races, teams);
        season2022.RunSeason();

        if (alsoPrintResults) {
            season2022.PrintSeasonResults();
        }
    }

    private static List<Race> AssembleRaces2022() => [
        new Race("Bahrain"),
        new Race("Saudi Arabia"),
        new Race("Australia"),
        new Race("Emilia Romagna"),
        new Race("Miami"),
        new Race("Spain"),
        new Race("Monaco"),
        new Race("Azerbaijan"),
        new Race("Canada"),
        new Race("Great Britain"),
        new Race("Austria"),
        new Race("France"),
        new Race("Hungary"),
        new Race("Belgium"),
        new Race("Netherlands"),
        new Race("Italy"),
        new Race("Singapore"),
        new Race("Japan"),
        new Race("United States"),
        new Race("Mexico"),
        new Race("Brazil"),
        new Race("Abu Dhabi"),
    ];

    public static List<Team> AssembleTeams2022() {
        List<Driver> drivers = GetDrivers();

        Team redbull = new("Red Bull Racing");
        redbull.ContractDriver(drivers[0]);
        redbull.ContractDriver(drivers[1]);
        Team ferrari = new("Ferrari");
        ferrari.ContractDriver(drivers[2]);
        ferrari.ContractDriver(drivers[3]);
        Team mercedes = new("Mercedes-AMG");
        mercedes.ContractDriver(drivers[4]);
        mercedes.ContractDriver(drivers[5]);
        Team alpine = new("Alpine-Renault");
        alpine.ContractDriver(drivers[6]);
        alpine.ContractDriver(drivers[7]);
        Team mclaren = new("McLaren-Mercedes");
        mclaren.ContractDriver(drivers[8]);
        mclaren.ContractDriver(drivers[9]);
        Team alfaRomeo = new("Alfa Romeo Racing-Ferrari");
        alfaRomeo.ContractDriver(drivers[10]);
        alfaRomeo.ContractDriver(drivers[11]);
        Team astonMartin = new("Aston Martin-Mercedes");
        astonMartin.ContractDriver(drivers[12]);
        astonMartin.ContractDriver(drivers[13]);
        Team haas = new("Haas-Ferrari");
        haas.ContractDriver(drivers[14]);
        haas.ContractDriver(drivers[15]);
        Team alphatauri = new("AlphaTauri-Red Bull");
        alphatauri.ContractDriver(drivers[16]);
        alphatauri.ContractDriver(drivers[17]);
        Team williams = new("Williams-Mercedes");
        williams.ContractDriver(drivers[18]);
        williams.ContractDriver(drivers[19]);

        return [
            redbull, ferrari, mercedes, alpine, mclaren,
            alfaRomeo, astonMartin, haas, alphatauri, williams];
    }

    private static bool AreDriverListsInSameOrder(List<Driver> list1, List<Driver> list2, List<Driver> list3) {
        if (list1.Count != list2.Count || list1.Count != list3.Count) {
            return false;
        }

        for (int i = 0; i < list1.Count; i++) {
            if (list1[i].Name != list2[i].Name || list1[i].Name != list3[i].Name) {
                return false;
            }
        }

        return true;
    }

    private static void PrintIsFieldReadOnly(Type clsType, string fieldName) {
        FieldInfo info = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (info is not null) {
            Console.WriteLine($"{info.Name} is a read-only field: " +
                info.IsInitOnly);
        } else {
            Console.WriteLine($"Field {fieldName} not found in {clsType.Name}");
        }
    }

    private static List<Driver> GetDrivers() => [
        new Driver("Max Verstappen"),
        new Driver("Sergio Perez"),
        new Driver("Charles Leclerc"),
        new Driver("Carlos Sainz Jr."),
        new Driver("Louis Hamilton"),
        new Driver("George Russel"),
        new Driver("Fernando Alonso"),
        new Driver("Esteban Ocon"),
        new Driver("Daniel Ricciardo"),
        new Driver("Lando Norris"),
        new Driver("Valtteri Bottas"),
        new Driver("Guanyu Zhou"),
        new Driver("Sebastian Vettel"),
        new Driver("Lance Stroll"),
        new Driver("Mick Schumacher"),
        new Driver("Kevin Magnussen"),
        new Driver("Pierre Gasly"),
        new Driver("Yuki Tsunoda"),
        new Driver("Alex Albon"),
        new Driver("Nicholas Latifi")
    ];
}
