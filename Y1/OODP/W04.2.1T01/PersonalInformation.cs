static class PersonalInformation {
    public static void PrintName(string Name) {
        Console.WriteLine(Name);
    }

    public static void PrintName(string FirstName, string LastName) {
        Console.WriteLine($"{FirstName} {LastName}");
    }

    public static void PrintName(char Initial, string LastName) {
        Console.WriteLine($"{Initial}. {LastName}");
    }

    public static int IncreaseSalary(int Salary) {
        return Salary + 100;
    }

    public static double IncreaseSalary(int Salary, double Increase) {
        return Salary * (1 + Increase);
    }
}
