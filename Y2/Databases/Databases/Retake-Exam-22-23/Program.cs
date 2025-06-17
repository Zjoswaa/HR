class Program {
    public static void openTest(ExamContext db) {
        Seed.SeedData(db, false);
        Console.WriteLine("1: Solution");
        Solution.Q1(db, "Glen");
        Console.WriteLine("2: Solution");
        Solution.Q2(db, 1);
        Console.WriteLine("3: Solution");
        Solution.Q3(db);
        Console.WriteLine("4: Solution");
        Solution.Q4(db, 2);
        Console.WriteLine("5: Solution");
        Solution.Q5(db);
        Console.WriteLine("6: Solution");
        Solution.Q6(db);
        Console.WriteLine("7: Solution");
        Solution.Q7(db, "NL", 10);
        Console.WriteLine("8: Solution");
        Solution.Q8(db, 100);
    }

    public static void Main(string[] args) {
        //first line of code is there to solve any issue with date-time format. 
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("EN-US");

        var db = new ExamContext();

        Seed.SeedData(db, true);

        switch (args[1]) {
            case "Q1":
                Solution.Q1(db, "Glen");
                return;
            case "Q2":
                Solution.Q2(db, 1);
                return;
            case "Q3":
                Solution.Q3(db);
                return;
            case "Q4":
                Solution.Q4(db, 4);
                return;
            case "Q5":
                Solution.Q5(db);
                return;
            case "Q6":
                Solution.Q6(db);
                return;
            case "Q7":
                Solution.Q7(db, "NL", 10);
                return;
            case "Q8":
                Solution.Q8(db, 10);
                return;
            case "ALL":
                openTest(db);
                return;
            default: throw new ArgumentException();
        }
    }
}
