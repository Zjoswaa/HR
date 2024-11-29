static class Converter {
    public static T2 ConvertVariables<T1, T2>(T1 From) {
        return (T2)Convert.ChangeType(From, typeof(T2));
    }
}
