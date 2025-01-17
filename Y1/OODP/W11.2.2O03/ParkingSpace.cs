class ParkingSpace {
    public int Row { get; }
    public int Col { get; }
    public int Size { get; }
    private Vehicle? _parkedVehicle = null;
    public Vehicle? ParkedVehicle {
        get {
            if (IsOccupied) {
                return null;
            }
            return _parkedVehicle;
        }
        private set {
            _parkedVehicle = value;
        }
    }
    public bool IsOccupied { get; } = false;

    public ParkingSpace(int Row, int Col, int Size) {
        this.Row = Row;
        this.Col = Col;
        this.Size = Size;
    }

    public bool ParkVehicle(Vehicle Vehicle) {
        if (!IsOccupied) {
            ParkedVehicle = Vehicle;
            return true;
        }
        return false;
    }
}
