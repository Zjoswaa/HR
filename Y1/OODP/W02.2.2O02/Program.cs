class Program {
    public static void Main(string[] args) {

        var today = new Todo();
        today.AddTask("T1");
        today.AddTask("T2");
        today.AddTask("T3");
        today.AddTask("T4");

        Task a = today.GetTask("T2");
        Task b = today.GetTask("T4");
        Task c = today.GetTask("T5");

        if (a != null) a.Done();
        if (b != null) b.Done();
        if (c != null) c.Done();

        Console.WriteLine(today.Report());
    }
}
