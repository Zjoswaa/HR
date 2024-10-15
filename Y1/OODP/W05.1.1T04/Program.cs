public class Program {
    public static void Main() {
        List<Motorcycle> motorcycles = new()
        {
            new Motorcycle("Yamaha", "R6", 2019),
            new Cruiser("Indian", "Chief", 2020, 64),
            new HarleyDavidson("Softail", 2022),
        };

        foreach (var m in motorcycles) {
            Console.WriteLine(m.Ride());
            if (m is HarleyDavidson && m is Cruiser)
                Console.WriteLine("{0} {1} is also a Motorcycle and a Cruiser",
                    m.Model, m.Make);
            else if (m is Cruiser)
                Console.WriteLine("{0} {1} is also a Motorcycle",
                    m.Model, m.Make);
            Console.WriteLine();
        }
    }
}
