static class RewardGenerator {
    private static Random _Random = new(0);

    public static T GetRandomElement<T>(List<T> List) {
        return List[_Random.Next(List.Count)];
    }
}
