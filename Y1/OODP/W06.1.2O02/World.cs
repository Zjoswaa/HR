static class World {
    public static bool IsDayTime { get; private set; } = true;
    public static void SwitchTime() => IsDayTime = !IsDayTime;
}
