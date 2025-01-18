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

    public static void GetAverageWeightDeviation(ContainerStatus status) {
        double avg = containerLog.Values.Where(c => c.Status == status).Average(c => c.Weight);
        Console.WriteLine($"Average Deviation from containers with status '{status}': {avg}");
    }

    public static void GetDistinctCategories(ContainerStatus status) {
        var distinct = containerLog.Values.DistinctBy(c => c.Categories.SelectMany(category => category.Distinct()));
        Console.WriteLine($"Distinct categories from containers with status '{status}': [{String.Join(',', distinct)}]");
    }
}
