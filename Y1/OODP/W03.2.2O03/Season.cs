class Season {
    public readonly int Year;
    public readonly List<Race> Races;
    public readonly List<Team> Teams;
    public static readonly List<int> PointsForPositions = [25, 18, 15, 12, 10, 8, 6, 4, 2, 1];

    public Season(int Year, List<Race> Races, List<Team> Teams) {
        this.Year = Year;
        this.Races = Races;
        this.Teams = Teams;
    }

    public void RunSeason() {
        // Get all drivers from all teams
        List<Driver> AllDrivers = [];
        foreach (Team Team in this.Teams) {
            AllDrivers.Add(Team.Drivers[0]);
            AllDrivers.Add(Team.Drivers[1]);
        }

        // Run every race
        foreach (Race Race in this.Races) {
            // Get race result
            List<Driver> RaceResults = Race.GetRaceResults(AllDrivers);
            // Print first place
            Console.WriteLine($"{RaceResults[0].Name} of {RaceResults[0].TeamName} has won the {Race.Location} Grand Prix!");
            // Add points to drivers in top 10
            for (int i = 0; i < 10; i++) {
                RaceResults[i].DriverPoints += PointsForPositions[i];
            }
        }
    }

    public void PrintSeasonResults() {
        List<Driver> AllDrivers = [];
        foreach (Team Team in this.Teams) {
            AllDrivers.Add(Team.Drivers[0]);
            AllDrivers.Add(Team.Drivers[1]);
        }

        AllDrivers = AllDrivers.OrderByDescending(o => o.DriverPoints).ToList();
        Console.WriteLine("Season results:");
        for (int i = 0; i < AllDrivers.Count; i++) {
            Console.WriteLine($"{i + 1}. {AllDrivers[i].Name}: {AllDrivers[i].DriverPoints}");
        }
    }
}
