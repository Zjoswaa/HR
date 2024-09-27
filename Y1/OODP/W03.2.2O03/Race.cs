class Race {
    public readonly string Location;

    public Race(string Location) {
        this.Location = Location;
    }

    public static List<Driver> GetRaceResults(List<Driver> Drivers) {
        Random rng = new Random();
        List<Driver> RandomList = Drivers;
        int n = RandomList.Count;

        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            Driver value = RandomList[k];
            RandomList[k] = RandomList[n];
            RandomList[n] = value;
        }

        return RandomList;
    }
}
