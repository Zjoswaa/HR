class EReader : IBorrow {
    public string Status { get; private set; } = "Available";
    public bool IsAvailable { get; private set; } = true;

    public void Borrow() {
        if (IsAvailable) {
            Console.WriteLine("EReader is available");
            IsAvailable = false;
            UpdateStatus();
        } else {
            Console.WriteLine("EReader is not available");
        }
    }

    public void UpdateStatus() {
        if (IsAvailable) {
            Status = "Available";
        } else {
            Status = "Borrowed";
        }
    }
}
