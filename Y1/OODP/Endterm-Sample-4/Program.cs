static class Program
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "CheckStatus": TestCheckStatus(); return;
            case "AddStudentToWaitList": TestAddStudentToWaitList(); return;
            case "EnrollNextStudent": TestEnrollNextStudent(); return;
            case "PrintByCity": TestPrintAddStudentToWaitListsByCity(); return;
            default: throw new ArgumentException();
        }
    }

    public static void TestCheckStatus()
    {
        EnrollmentSystem.AddStudentToWaitList("John Doe", "123", "Rotterdam", Course.Django);
        Console.WriteLine(EnrollmentSystem.CheckStatus("123"));

        EnrollmentSystem.AddStudentToWaitList("Jane Doe", "456", "Amsterdam", Course.OODP);
        EnrollmentSystem.EnrollNextStudent(Course.OODP);
        Console.WriteLine(EnrollmentSystem.CheckStatus("123"));
        Console.WriteLine(EnrollmentSystem.CheckStatus("456"));

        Console.WriteLine(EnrollmentSystem.CheckStatus("789"));
        Console.WriteLine(EnrollmentSystem.CheckStatus("321"));
    }

    public static void TestAddStudentToWaitList()
    {
        EnrollmentSystem.AddStudentToWaitList("John Doe", "123", "Rotterdam", Course.Django);
        Console.WriteLine(EnrollmentSystem.CheckStatus("123"));
        EnrollmentSystem.AddStudentToWaitList("Jane Doe", "456", "Amsterdam", Course.OODP);
        Console.WriteLine(EnrollmentSystem.CheckStatus("456"));
    }

    public static void TestEnrollNextStudent()
    {
        EnrollmentSystem.AddStudentToWaitList("John Doe", "123", "Rotterdam", Course.Django);
        EnrollmentSystem.AddStudentToWaitList("Jane Doe", "456", "Amsterdam", Course.Django);
        EnrollmentSystem.AddStudentToWaitList("John Smith", "789", "Leiden", Course.Django);
        EnrollmentSystem.EnrollNextStudent(Course.Django);
        Console.WriteLine(EnrollmentSystem.CheckStatus("123"));
        Console.WriteLine(EnrollmentSystem.CheckStatus("456"));
        Console.WriteLine(EnrollmentSystem.CheckStatus("789"));
    }

    public static void TestPrintAddStudentToWaitListsByCity()
    {
        AddStudentsToCourses1();
        Console.WriteLine("====== Testing batch 1 ======");
        foreach (Course course in Enum.GetValues(typeof(Course)))
        {
            Console.WriteLine($"\n=== Course: {course} ===\n");
            EnrollmentSystem.PrintEnrolledStudentsPerCity(course);
        }

        RemoveEnrolledStudents();

        AddStudentsToCourses2();
        Console.WriteLine("\n====== Testing batch 2 ======");
        foreach (Course course in Enum.GetValues(typeof(Course)))
        {
            Console.WriteLine($"\n=== Course: {course} ===\n");
            EnrollmentSystem.PrintEnrolledStudentsPerCity(course);
        }
    }

    private static void AddStudentsToCourses1()
    {
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("John Doe", "123", "Rotterdam"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Jane Doe", "456", "Amsterdam"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("John Smith", "789", "Leiden"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Piet Hein", "753", "Den Haag"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Alice Brown", "001", "Rotterdam"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Bob White", "002", "Amsterdam"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Charlie Black", "003", "Leiden"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Diana Green", "004", "Den Haag"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Eve Blue", "005", "Utrecht"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Frank Red", "006", "Groningen"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Grace Yellow", "007", "Eindhoven"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Hank Purple", "008", "Maastricht"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Ivy Orange", "009", "Rotterdam"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Jack Gray", "010", "Amsterdam"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Karen Cyan", "011", "Leiden"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Leo Magenta", "012", "Den Haag"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Mia Pink", "013", "Utrecht"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Nina Aqua", "014", "Groningen"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Oscar Teal", "015", "Eindhoven"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Paul Silver", "016", "Maastricht"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Quinn Gold", "017", "Rotterdam"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Ray Bronze", "018", "Amsterdam"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Sara Copper", "019", "Leiden"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Tom Brass", "020", "Den Haag"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Uma Chrome", "021", "Utrecht"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Vera Nickel", "022", "Groningen"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Will Platinum", "023", "Eindhoven"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Xena Titanium", "024", "Maastricht"));
    }

    private static void AddStudentsToCourses2()
    {
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Yara Zinc", "025", "Rotterdam"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Zane Quartz", "026", "Amsterdam"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Aaron Flint", "027", "Leiden"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Bella Slate", "028", "Den Haag"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Cody Onyx", "029", "Utrecht"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Dana Marble", "030", "Groningen"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Ella Pearl", "031", "Eindhoven"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Felix Jade", "032", "Maastricht"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Gina Ruby", "033", "Rotterdam"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Hank Emerald", "034", "Amsterdam"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Ivy Topaz", "035", "Leiden"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Jack Sapphire", "036", "Den Haag"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Kara Garnet", "037", "Utrecht"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Liam Amethyst", "038", "Groningen"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Mia Beryl", "039", "Eindhoven"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Nina Amber", "040", "Maastricht"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Oscar Citrine", "041", "Rotterdam"));
        EnrollmentSystem.EnrolledStudents[Course.OODP].Add(new("Paula Opal", "042", "Amsterdam"));
        EnrollmentSystem.EnrolledStudents[Course.Project].Add(new("Quinn Jasper", "043", "Leiden"));
        EnrollmentSystem.EnrolledStudents[Course.Django].Add(new("Ralph Turquoise", "044", "Den Haag"));
    }

    private static void RemoveEnrolledStudents()
    {
        foreach (Course course in Enum.GetValues(typeof(Course)))
        {
            EnrollmentSystem.EnrolledStudents[course].Clear();
        }
    }
}
