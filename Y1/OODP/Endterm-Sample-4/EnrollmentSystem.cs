enum Course {
    Django,
    OODP,
    Project
}

static class EnrollmentSystem {
    public static Dictionary<Course, Queue<Student>> WaitList = new()
    {
        { Course.Django, new Queue<Student>() },
        { Course.OODP, new Queue<Student>() },
        { Course.Project, new Queue<Student>() }
    };

    public static Dictionary<Course, List<Student>> EnrolledStudents = new()
    {
        { Course.Django, new List<Student>() },
        { Course.OODP, new List<Student>() },
        { Course.Project, new List<Student>() }
    };

    public static void AddStudentToWaitList(string name, string id, string city, Course course) {
        WaitList[course].Enqueue(new Student(name, id, city));
    }

    public static string CheckStatus(string id) {
        foreach (Course course in Enum.GetValues(typeof(Course))) {
            foreach (Student student in EnrolledStudents[course]) {
                if (student.ID == id) {
                    return $"Student {id} is enrolled in {course}";
                }
            }
            foreach (Student student in WaitList[course]) {
                if (student.ID == id) {
                    return $"Student {id} is in the waitlist for {course}";
                }
            }
        }

        return $"Student {id} not found";
    }

    public static void EnrollNextStudent(Course course) {
        Student NextStudent = WaitList[course].Dequeue();
        EnrolledStudents[course].Add(NextStudent);
    }

    public static void PrintEnrolledStudentsPerCity(Course course) {
        IEnumerable<string> DistinctCities = EnrolledStudents[course].OrderBy(s => s.City).DistinctBy(s => s.City).Select(s => s.City);
        foreach (string city in DistinctCities) {
            Console.WriteLine($"City: {city}");
            IEnumerable<Student> StudentsInCity = EnrolledStudents[course].Where(s => s.City == city);
            foreach (Student student in StudentsInCity) {
                Console.WriteLine($" - {student.Name}");
            }
        }
    }
}
