List<double> grades = new() { 7.0, 5.5, 3.2, 10.0, 4.5 };
int passed = 0;

foreach (double grade in grades) {
    if (grade >= 5.5) {
        passed++;
    }
}

Console.WriteLine($"{passed} out of {grades.Count} students passed");
