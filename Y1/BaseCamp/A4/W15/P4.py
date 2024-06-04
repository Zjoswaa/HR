from result import Result
from student import Student
from course import Course
from resultsmanager import ResultsManager


if __name__ == "__main__":
    manager = ResultsManager()
    manager.create_tables()

    course_development = manager.get_course(1)
    course_skills = manager.get_course(2)

    if not course_development:
        course_development = manager.add_course(Course("Development 101", 4))
    if not course_skills:
        course_skills = manager.add_course(Course("Skills", 2))

    john = manager.get_student(1)
    jane = manager.get_student(2)

    # print(john)

    if not john:
        john = manager.add_student(Student("John", "Doe", "2003-08-12", "BC11A"))
        manager.add_result(Result(john.id, course_development.id, 50, "2023-03-18"))
        manager.add_result(Result(john.id, course_development.id, 40, "2023-05-05"))  # should not be added
        manager.add_result(Result(john.id, course_development.id, 70, "2023-06-22"))
    if not jane:
        jane = manager.add_student(Student("Jane", "Doe", "2004-02-24", "BC11F"))
        manager.add_result(Result(jane.id, course_skills.id, 40, "2023-03-19"))
        manager.add_result(Result(jane.id, course_skills.id, 30, "2023-05-03"))  # should not be added
        manager.add_result(Result(jane.id, course_skills.id, 80, "2023-06-27"))

    # print(manager.get_results_by_student(john.id, True))
    # print(manager.get_results_by_student(john.id, False))
    # print(manager.get_results_by_course(course_development.id, True))
    # print(manager.get_results_by_course(course_development.id, False))

    # print(john.get_full_name())
    # print(john.get_age())
    # print(manager.get_remaining_students())

    # print(manager.get_student_total_points(john.id))
    # print(manager.get_student_courses(john.id))

    manager.close()
