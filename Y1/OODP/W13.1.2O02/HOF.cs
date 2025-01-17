static class HOF {
    public static List<T> Filter<T>(List<T> list, Func<T, bool> func) {
        return list.Where(i => func(i)).ToList();
    }
}
