static class CleaningService {
    public static void Clean(ICleanable Cleanable) {
        Cleanable.Clean();
    }

    public static void Clean(List<ICleanable> Cleanables) {
        foreach (ICleanable Cleanable in Cleanables) {
            Cleanable.Clean();
        }
    }
}
