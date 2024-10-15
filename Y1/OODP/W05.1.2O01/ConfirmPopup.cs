class ConfirmPopup : Popup {
    public CoolApplication MyOwner;
    public Button CancelBtn;
    public Button OkBtn;

    public ConfirmPopup(CoolApplication MyOwner) : base("Are you sure? (y/n)") {
        this.MyOwner = MyOwner;
        this.CreateButtons();
    }

    private void CreateButtons() {
        CancelBtn = new Button("Cancel", this, sender => Console.WriteLine("Cancelled"));
        OkBtn = new Button("OK", this, sender => MyOwner.ConfirmButtonPressed());
    }

    public override void Display() => Console.WriteLine($"{base.Message} {this.Message}");
}
