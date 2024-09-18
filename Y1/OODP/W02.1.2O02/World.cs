public static class World {
    public static readonly List<Location> Locations = new List<Location>();

    public const int LOCATION_ID_LOC1 = 1;
    public const int LOCATION_ID_LOC2 = 2;
    public const int LOCATION_ID_LOC3 = 3;
    public const int LOCATION_ID_LOC4 = 4;
    public const int LOCATION_ID_LOC5 = 5;
    public const int LOCATION_ID_LOC6 = 6;

    static World() => PopulateLocations();

    private static void PopulateLocations() {
        // Create each location
        Location loc1Start = new Location(LOCATION_ID_LOC1, "Start");
        Location loc2 = new Location(LOCATION_ID_LOC2, "Empty location");
        Location loc3 = new Location(LOCATION_ID_LOC3, "Empty location");
        Location loc4 = new Location(LOCATION_ID_LOC4, "Empty location");
        Location loc5 = new Location(LOCATION_ID_LOC5, "Empty location");
        Location loc6Goal = new Location(LOCATION_ID_LOC6, "Goal");

        /* Map of locations
         * +---+
         * |123|
         * | 4 |
         * | 56|
         * +---+
         */

        // Link the locations together
        loc1Start.LocationToEast = loc2;

        loc2.LocationToEast = loc3;
        loc2.LocationToSouth = loc4;
        loc2.LocationToWest = loc1Start;

        loc3.LocationToWest = loc2;

        loc4.LocationToNorth = loc2;
        loc4.LocationToSouth = loc5;

        loc5.LocationToNorth = loc4;
        loc5.LocationToEast = loc6Goal;

        loc6Goal.LocationToWest = loc5;

        Locations.Add(loc1Start);
        Locations.Add(loc2);
        Locations.Add(loc3);
        Locations.Add(loc4);
        Locations.Add(loc5);
        Locations.Add(loc6Goal);
    }
}
