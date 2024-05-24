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
        marks = {}  # Max result per course id
        query = "SELECT * FROM results WHERE student_id=?"
        self.dbc.execute(query, [student_id])
        query_results = self.dbc.fetchall()
        if not only_last:
            return query_results

        # Else get only the highest marks per course
        for query_result in query_results:
            if query_result[1] not in marks:
                marks[query_result[1]] = query_result
            elif query_result[2] > marks[query_result[1]][2]:  # If the result is higher than the saved result
                marks[query_result[1]] = query_result
        return list(marks.values())

    def get_results_by_course(self, course_id, only_last=True):
        marks = {}  # Max result per student id
        query = "SELECT * FROM results WHERE course_id=?"
        self.dbc.execute(query, [course_id])
        query_results = self.dbc.fetchall()
        if not only_last:
            return query_results

        # Else get only the highest mark per student
        for query_result in query_results:
            if query_result[0] not in marks:
                marks[query_result[0]] = query_result
            elif query_result[2] > marks[query_result[0]][2]:  # If the result is higher than the saved result
                marks[query_result[0]] = query_result
        return list(marks.values())

    def close(self):
        self.conn.close()
