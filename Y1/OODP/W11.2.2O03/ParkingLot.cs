class ParkingLot {
    public int[] NumColsArr { get; }
    public ParkingSpace[][] ParkingSpaces { get; set; }

    public ParkingLot(int[] NumColsArr) {
        this.NumColsArr = NumColsArr;
        ParkingSpaces = new ParkingSpace[NumColsArr.Length][];

        for (int i = 0; i < NumColsArr.Length; i++) {
            Array.Resize(ref ParkingSpaces[i], NumColsArr[i]);
            for (int j = 0; j < NumColsArr[i]; j++) {
                ParkingSpaces[i][j] = new ParkingSpace(i, j, NumColsArr[i] <= 4 ? 2 : 1);
            }
        }
    }

    public bool ParkVehicle(Vehicle Vehicle, ParkingSpace ParkingSpace) {
        return ParkingSpace.ParkVehicle(Vehicle);
    }

    public ParkingSpace? FindAvailableSpace(Vehicle Vehicle) {
        for (int i = 0; i < ParkingSpaces.Length; i++) {
            for (int j = 0; j < ParkingSpaces[i].Length; j++) {
                if (!ParkingSpaces[i][j].IsOccupied && ParkingSpaces[i][j].Size == Vehicle.Size) {
                    return ParkingSpaces[i][j];
                }
            }
        }
        return null;
    }

    public int NumCarsParked() {
        int Counter = 0;
        for (int i = 0; i < ParkingSpaces.Length; i++) {
            for (int j = 0; j < ParkingSpaces[i].Length; j++) {
                if (ParkingSpaces[i][j].IsOccupied && ParkingSpaces[i][j].Size == 1) {
                    Counter++;
                }
            }
        }
        return Counter;
    }

    public int NumTrucksParked() {
        int Counter = 0;
        for (int i = 0; i < ParkingSpaces.Length; i++) {
            for (int j = 0; j < ParkingSpaces[i].Length; j++) {
                if (ParkingSpaces[i][j].IsOccupied && ParkingSpaces[i][j].Size == 2) {
                    Counter++;
                }
            }
        }
        return Counter;
    }
}
