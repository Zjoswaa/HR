public static class ContainerLogger {
    public static Dictionary<string, Container> containerLog = new();

    public static void Log(Container Container) {
        containerLog[Container.Code] = Container;
    }

    public static void Print() {
        foreach (KeyValuePair<string, Container> KVP in containerLog) {
            Console.WriteLine(KVP.Value);
        }
    }
}
