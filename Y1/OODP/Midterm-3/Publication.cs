abstract class Publication : IBorrow {
    public string Title { get; }
    public string Status { get; protected set; } = "Available";

    protected Publication(string title) => Title = title;

    public abstract void Borrow();
    public abstract void UpdateStatus();
}
