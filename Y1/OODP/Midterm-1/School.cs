static class School {
    public const int AnnualTeacherFunding = 300000;
    public static List<Teacher> Teachers { get; set; } = new();

    static public void HireTeacher(string name, int salary) {
        Teachers.Add(new Teacher(name, salary));
    }

    public static List<int> GetAnnualSalaries() {
        List<int> AnnualSalaries = new();
        foreach (Teacher t in Teachers) {
            AnnualSalaries.Add(t.GetAnnualSalary());
        }
        return AnnualSalaries;
    }

    public static bool IsFundingSufficient() {
        List<int> Salaries = GetAnnualSalaries();
        int TotalSalaries = 0;
        foreach (int salary in Salaries) {
            TotalSalaries += salary;
        }
        return TotalSalaries <= AnnualTeacherFunding;
    }
}
