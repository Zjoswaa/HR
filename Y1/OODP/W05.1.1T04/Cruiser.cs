class Cruiser : Motorcycle {
    public int SeatHeight;

    public Cruiser(string make, string model, int year, int seatheight) : base(make, model, year) {
        SeatHeight = seatheight;
    }

    public override string Ride() => base.Ride() + $" with a seat height of {SeatHeight} cm";
}
