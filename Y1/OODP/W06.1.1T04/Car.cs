public class Car : ICleanable {
    public bool IsClean { get; private set; }
    public string Info {
        get => $"{ToString()} is {(IsClean ? "clean" : "dirty")}";
    }

    public Car() => IsClean = true;

    public void Clean() => IsClean = true;
    public void Drive() => IsClean = false;
}
