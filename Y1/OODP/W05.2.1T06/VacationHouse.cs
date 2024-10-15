public class VacationHouse : House {
    public VacationHouse(double squareMeters, int numberOfRooms) : base(squareMeters, numberOfRooms, true, true) { }

    public override void HomeImprovement() {
        base.HomeImprovement();
        NumberOfRooms++;
    }
}
