List<double> grades = new() { 6.5, 9.5, 4, 5, 4.5, 10, 7.1 };

for (int i = 0; i < grades.Count; i++) {
    Console.WriteLine($"Grade: {grades[i]}");
    if (grades[i] < 5.5) {
        while (true) {
            Console.WriteLine("Retake this course? y/n");
            string input = Console.ReadLine().ToUpper();
            if (input == "Y") {
                grades[i] += 1.0;
                break;
            } else if (input == "N") {
                break;
            }
        }
    }
}

Console.WriteLine("Final grades:");
for (int i = 0; i < grades.Count; i++) {
    Console.WriteLine(grades[i]);
}
