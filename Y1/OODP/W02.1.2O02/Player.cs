public class Player {
    public Location CurrentLocation;
    public Player(Location currentLocation) {
        CurrentLocation = currentLocation;
    }

    public bool TryMoveTo(Location newLocation) {
        if (newLocation != null) {
            CurrentLocation = newLocation;
            return true;
        }
        return false;
    }
}
