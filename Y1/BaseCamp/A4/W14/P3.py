from result import Result
from student import Student
from course import Course
from resultsmanager import ResultsManager


if __name__ == "__main__":
    manager = ResultsManager()
    manager.create_tables()

    course_development = manager.get_course(1)

    if not course_development:
        course_development = manager.add_course(Course("Development 101", 4))

    john = manager.get_student(1)

    # print(john)

    if not john:
        john = manager.add_student(Student("John", "Doe", "2003-08-12", "BC11A"))
        manager.add_result(Result(john.id, course_development.id, 50, "2023-03-18"))
        manager.add_result(Result(john.id, course_development.id, 40, "2023-05-05"))  # should not be added
        manager.add_result(Result(john.id, course_development.id, 70, "2023-06-22"))

    print(manager.get_results_by_student(john.id))

    print(manager.get_results_by_course(course_development.id, False))

    manager.close()
