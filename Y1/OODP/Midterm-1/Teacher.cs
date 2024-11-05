class Teacher {
    public readonly string Name;
    public int MonthlySalary { get; set; }
    public readonly string Code;
    public const string BaseCode = "TeacherID";
    public static int AmountOfTeachers;

    public Teacher(string name, int monthlySalary) {
        Name = name;
        MonthlySalary = monthlySalary;
        Code = $"{BaseCode}{++AmountOfTeachers}";
    }

    public int GetAnnualSalary() {
        return MonthlySalary * 13;
    }
}
