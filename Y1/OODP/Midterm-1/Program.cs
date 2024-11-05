using System.Reflection;

static class Program {
    static void Main(string[] args) {
        switch (args[1]) {
            case "Static": TestStatic(); return;
            case "Readonly": TestReadOnlyFields(); return;
            case "Constant": TestConstFields(); return;
            case "TeacherNameMonthlySalary": TestTeacherNameMonthlySalary(); return;
            case "TeacherAnnualSalary": TestTeacherAnnualSalary(); return;
            case "TeacherCode": TestTeacherCode(); return;
            case "SchoolSalaries": TestSchoolSalaries(); return;
            case "SchoolDeficit": TestSchoolDeficit(); return;
            default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestStatic() {
        Console.WriteLine($"Amount of teachers: {Teacher.AmountOfTeachers}"); // 0

        Teacher teacher = new("John", 4000);
        Console.WriteLine($"Amount of teachers after creating 1: " +
            $"{Teacher.AmountOfTeachers}"); // Should be 1

        List<Teacher> teachers = [
            new("Jane", 4000),
            new("Jack", 4500),
            new("Josh", 3500),
            new("Joan", 4500),
            new("Joey", 4000),
        ];

        Console.WriteLine($"Amount of teachers after creating {teachers.Count} more: " +
            $"{Teacher.AmountOfTeachers}"); // 6

        Type type = typeof(School);
        Console.WriteLine($"\n{type} is a static class: "
            + (type.IsAbstract && type.IsSealed));

        Console.WriteLine($"School annual funding: {School.AnnualTeacherFunding}");

        Console.WriteLine($"Teachers hired: {School.Teachers.Count}"); // Should be 0
        Console.WriteLine("Hiring teacher...");
        School.HireTeacher("John", 4000);
        Console.WriteLine($"Teachers hired: {School.Teachers.Count}"); // Should be 1
    }

    public static void TestReadOnlyFields() {
        Type clsType = typeof(Teacher);
        PrintIsFieldReadOnly(clsType, "Name");
        PrintIsFieldReadOnly(clsType, "Code");
    }

    public static void TestConstFields() {
        Type clsType = typeof(Teacher);
        PrintIsFieldConstant(clsType, "BaseCode");
        clsType = typeof(School);
        PrintIsFieldConstant(clsType, "AnnualTeacherFunding");
    }

    public static void TestTeacherNameMonthlySalary() {
        List<Teacher> teachers = [
            new("John", 4000),
            new("Jane", 4000),
            new("Jack", 4500),
            new("Josh", 3500),
            new("Joan", 4500),
            new("Joey", 4000),
        ];

        foreach (var teacher in teachers) {
            Console.WriteLine($"Name: {teacher.Name}");
            Console.WriteLine($" - Monthly salary: {teacher.MonthlySalary}");
        }
    }

    public static void TestTeacherAnnualSalary() {
        List<Teacher> teachers = [
            new("John", 4000),
            new("Jane", 4000),
            new("Jack", 4500),
            new("Josh", 3500),
            new("Joan", 4500),
            new("Joey", 4000),
        ];

        foreach (var teacher in teachers) {
            Console.WriteLine($"Name: {teacher.Name}");
            Console.WriteLine($" - Monthly salary: {teacher.MonthlySalary}");
            Console.WriteLine($" - Annual salary: {teacher.GetAnnualSalary()}");
        }
    }

    public static void TestTeacherCode() {
        List<Teacher> teachers = [
            new("John", 4000),
            new("Jane", 4000),
            new("Jack", 4500),
            new("Josh", 3500),
            new("Joan", 4500),
            new("Joey", 4000),
        ];

        foreach (var teacher in teachers) {
            Console.WriteLine($"Code: {teacher.Code}");
        }
    }

    public static void TestSchoolSalaries() {
        School.HireTeacher("John", 4000);
        School.HireTeacher("Jane", 4000);
        School.HireTeacher("Jack", 4500);
        School.HireTeacher("Josh", 3500);
        School.HireTeacher("Joan", 4500);
        School.HireTeacher("Joey", 4000);

        List<int> salaries = School.GetAnnualSalaries();
        salaries.Sort();
        Console.WriteLine("Salaries to pay:");
        foreach (var s in salaries)
            Console.WriteLine(s);

        School.HireTeacher("Jess", 3500);
        salaries = School.GetAnnualSalaries();
        salaries.Sort();
        Console.WriteLine("\nSalaries to pay:");
        foreach (var s in salaries)
            Console.WriteLine(s);

        School.HireTeacher("Jade", 4500);
        salaries = School.GetAnnualSalaries();
        salaries.Sort();
        Console.WriteLine("\nSalaries to pay:");
        foreach (var s in salaries) {
            Console.WriteLine(s);
        }
    }

    public static void TestSchoolDeficit() {
        School.HireTeacher("John", 4000);
        School.HireTeacher("Jane", 4000);
        School.HireTeacher("Jack", 4500);
        Console.WriteLine("Total annual salaries: 150000");
        PrintIsFundingSufficient();

        School.HireTeacher("Josh", 3500);
        Console.WriteLine("\nTotal annual salaries: 192000");
        PrintIsFundingSufficient();

        School.HireTeacher("Joan", 4500);
        School.HireTeacher("Joey", 4000);
        School.HireTeacher("Jess", 3500);
        Console.WriteLine("\nTotal annual salaries: 336000");
        PrintIsFundingSufficient();

        School.HireTeacher("Jade", 4500);
        Console.WriteLine("\nTotal annual salaries: 390000");
        PrintIsFundingSufficient();
    }

    static void PrintIsFundingSufficient() {
        Console.WriteLine($"The teacher funding is sufficient: " +
            $"{School.IsFundingSufficient()}");
    }

    private static void PrintIsFieldReadOnly(Type clsType, string fieldName) {
        FieldInfo? info = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (info is null) {
            Console.WriteLine($"Field {fieldName} not found in {clsType.Name}");
            return;
        }

        Console.WriteLine($"{info.Name} is a read-only field: " +
            info.IsInitOnly);
    }

    private static void PrintIsFieldConstant(Type clsType, string fieldName) {
        FieldInfo? info = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (info is null) {
            Console.WriteLine($"Field {fieldName} not found in {clsType.Name}");
            return;
        }

        Console.WriteLine($"{info.Name} is a constant field: " +
            info.IsLiteral);
    }
}
