public class Office : ICleanable {
    public bool IsClean { get; private set; }
    public string Info {
        get => $"{ToString()} is {(IsClean ? "clean" : "dirty")}";
    }

    public Office() => IsClean = true;

    public void Clean() => IsClean = true;
    public void Use() => IsClean = false;
}
