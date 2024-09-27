class Team {
    public readonly string Name;
    public readonly List<Driver> Drivers = [];

    public Team(string Name) {
        this.Name = Name;
    }

    public void ContractDriver(Driver Driver) {
        if (this.Drivers.Count >= 2) {
            return;
        }
        Driver.TeamName = this.Name;
        this.Drivers.Add(Driver);
    }
}
