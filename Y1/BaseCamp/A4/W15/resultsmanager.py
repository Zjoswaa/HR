import os
import sys
import sqlite3

from result import Result
from student import Student
from course import Course


class ResultsManager:
    def __init__(self):
        self.conn = sqlite3.connect(os.path.join(
            sys.path[0], 'studentresults.db'))
        self.dbc = self.conn.cursor()

    def create_tables(self):
        self.dbc.execute('''CREATE TABLE IF NOT EXISTS courses
                         (id INTEGER PRIMARY KEY AUTOINCREMENT,
                          name TEXT NOT NULL,
                          points INTEGER NOT NULL);''')

        self.dbc.execute('''CREATE TABLE IF NOT EXISTS students
                         (id INTEGER PRIMARY KEY AUTOINCREMENT,
                          first_name TEXT NOT NULL,
                          last_name TEXT NOT NULL,
                          date_of_birth DATE NOT NULL,
                          class_code TEXT NULL);''')

        self.dbc.execute('''CREATE TABLE IF NOT EXISTS results
                         (student_id INTEGER NOT NULL,
                          course_id INTEGER NOT NULL,
                          mark INTEGER NOT NULL,
                          achieved DATE NOT NULL,
                          PRIMARY KEY(student_id, course_id, mark));''')

        self.conn.commit()

    def get_course(self, course_id) -> Course | None:
        query = f"SELECT * FROM courses WHERE id={course_id} LIMIT 1"
        self.dbc.execute(query)
        query_result = self.dbc.fetchone()

        if query_result is None:  # If the query returned nothing
            return None
        return Course(query_result[1], query_result[2], query_result[0])

    def add_course(self, course: Course) -> Course:
        query = "INSERT INTO courses(name, points) VALUES (?, ?)"
        self.dbc.execute(query, [course.name, course.points])
        self.conn.commit()

        course.id = self.dbc.lastrowid
        return course

    def get_student(self, student_id) -> Student | None:
        query = f"SELECT * FROM main.students WHERE id={student_id} LIMIT 1"
        self.dbc.execute(query)
        query_result = self.dbc.fetchone()

        if query_result is None:  # If the query returned nothing
            return None
        return Student(query_result[1], query_result[2], query_result[3], query_result[4], query_result[0])

    def add_student(self, student: Student) -> Student:
        query = "INSERT INTO students(first_name, last_name, date_of_birth, class_code) VALUES (?, ?, ?, ?)"
        self.dbc.execute(query, [student.first_name,
                                 student.last_name,
                                 student.date_of_birth,
                                 student.class_code]
                         )
        self.conn.commit()

        student.id = self.dbc.lastrowid
        return student

    def add_result(self, result: Result) -> bool:
        select_query = "SELECT * FROM results WHERE student_id=? AND course_id=? LIMIT 1"
        insert_query = "INSERT INTO results(student_id, course_id, mark, achieved) VALUES (?, ?, ?, ?)"
        self.dbc.execute(select_query, [result.student_id, result.course_id])
        query_result = self.dbc.fetchone()

        if query_result is None:  # The search returned nothing
            self.dbc.execute(insert_query, [result.student_id, result.course_id, result.mark, result.achieved])
            self.conn.commit()
            return True

        # Else the search returned something, so check if the new mark is higher
        if result.mark < query_result[2]:  # If the new mark is less than the mark in the database
            return False
        # Else replace the mark
        self.dbc.execute(insert_query, [result.student_id, result.course_id, result.mark, result.achieved])
        self.conn.commit()
        return True

    def get_results_by_student(self, student_id, only_last=True):
        to_return = []
        marks = {}  # Max result per course id
        query = "SELECT * FROM results WHERE student_id=? ORDER BY mark"
        self.dbc.execute(query, [student_id])
        query_results = self.dbc.fetchall()
        for query_result in query_results:
            if query_result[1] not in marks:
                marks[query_result[1]] = [query_result]
            else:
                marks[query_result[1]].append(query_result)

        # print(marks)
        for course_id, result in marks.items():
            query = "SELECT * FROM courses WHERE id=? LIMIT 1"
            self.dbc.execute(query, [course_id])
            query_result = self.dbc.fetchone()
            if only_last:
                results = [{"mark": marks[course_id][-1][2], "achieved": marks[course_id][-1][3]}]
            else:
                results = []
                for mark in marks[course_id]:
                    results.append({"mark": mark[2], "achieved": mark[3]})
            to_return.append({"id": course_id,
                              "name": query_result[1],
                              "points": query_result[2],
                              "results": results})
        return to_return

    def get_results_by_course(self, course_id, only_last=True):
        to_return = []
        marks = {}  # Max result per student id
        query = "SELECT * FROM results WHERE course_id=? ORDER BY mark"
        self.dbc.execute(query, [course_id])
        query_results = self.dbc.fetchall()
        for query_result in query_results:
            if query_result[1] not in marks:
                marks[query_result[1]] = [query_result]
            else:
                marks[query_result[1]].append(query_result)

        # print(marks)
        for student_id, result in marks.items():
            query = "SELECT * FROM students WHERE id=? LIMIT 1"
            self.dbc.execute(query, [student_id])
            query_result = self.dbc.fetchone()
            if only_last:
                results = [{"mark": marks[course_id][-1][2], "achieved": marks[course_id][-1][3]}]
            else:
                results = []
                for mark in marks[course_id]:
                    results.append({"mark": mark[2], "achieved": mark[3]})

            to_return.append({"id": course_id,
                              "name": query_result[1] + " " + query_result[2],
                              "date_of_birth": query_result[3],
                              "results": results})

        return to_return

    def get_remaining_students(self):
        to_return = {}
        query = "SELECT * FROM results ORDER BY student_id, mark"
        self.dbc.execute(query)
        for query_result in self.dbc.fetchall():
            self.dbc.execute("SELECT * FROM students WHERE id=? LIMIT 1", [query_result[0]])
            student_result = self.dbc.fetchone()
            if query_result[0] not in to_return:
                total_points = self.get_student_total_points(query_result[0])
                if total_points < 60:
                    to_return[query_result[0]] = {"id": query_result[0],
                                                  "name": student_result[1] + " " + student_result[2],
                                                  "date_of_birth": student_result[3],
                                                  "total_points": total_points,
                                                  "courses": self.get_student_courses(query_result[0])}
        return list(to_return.values())

    def get_student_total_points(self, student_id: int):
        total = 0
        query = "SELECT course_id FROM RESULTS WHERE student_id=? AND mark>?"
        self.dbc.execute(query, [student_id, 55])
        for course_id in list(set(self.dbc.fetchall()[0])):
            self.dbc.execute("SELECT points FROM courses WHERE id=? LIMIT 1", [course_id])
            total += self.dbc.fetchone()[0]
        return total

    def get_student_courses(self, student_id: int):
        courses = []
        query = "SELECT course_id, mark, achieved FROM results WHERE student_id=?"
        self.dbc.execute(query, [student_id])
        for query_result in self.dbc.fetchall():
            query = "SELECT name, points FROM courses WHERE id=? LIMIT 1"
            self.dbc.execute(query, [query_result[0]])
            course_result = self.dbc.fetchone()
            courses.append({"id": query_result[0],
                            "name": course_result[0],
                            "points": course_result[1],
                            "passed": query_result[1] >= 55,
                            "mark": query_result[1],
                            "achieved": query_result[2]})
        return courses

    def close(self):
        self.conn.close()
