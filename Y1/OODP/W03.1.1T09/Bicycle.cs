class Bicycle {
    public Person Owner;
    public readonly string FrameNumber;
    public int CurrentGear;
    public string Color;

    public Bicycle(Person owner, string number, string color) {
        Owner = owner;
        FrameNumber = number;
        Color = color;
        CurrentGear = 1;
    }

    public void ChangeOwner(Person newOwner) => Owner = newOwner;
    public void ChangeGear(int gear) => CurrentGear = gear;
    public void Paint(string color) => Color = color;
}
