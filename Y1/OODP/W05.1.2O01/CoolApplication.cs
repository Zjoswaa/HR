class CoolApplication {
    public Button DoSomethingBtn;

    public CoolApplication() {
        CreateApplication();
        Popup welcome = new("Welcome to this awesome app!");
        welcome.Show();
    }

    private void CreateApplication() {
        DoSomethingBtn = new Button("Do something cool!", this, sender => HandleConfirm());
    }

    private void HandleConfirm() {
        ConfirmPopup confirmPopup = new ConfirmPopup(this);
        Console.WriteLine(confirmPopup.Message);

        string input;
        do {
            input = Console.ReadLine().ToLower();
        }
        while (input != "y" && input != "n");
        if (input == "n")
            confirmPopup.CancelBtn.Press();
        else
            confirmPopup.OkBtn.Press();
    }

    public void CancelButtonPressed() {
        Console.WriteLine("Operation cancelled.");
    }

    public void ConfirmButtonPressed() {
        Console.WriteLine("Operation confirmed.");
        FormatHardDrive();
    }

    private void FormatHardDrive() {
        ProgressPopup progressPopup = new("Formatting hard drive...");
        int hardDiskVolumePercentage = 100;
        int percentageChange = 15;

        while (hardDiskVolumePercentage > 0) {
            //Console.WriteLine("Here");
            hardDiskVolumePercentage -= percentageChange;
            progressPopup.IncreaseProgress(percentageChange);
        }
    }
}
