import os
import sys
import sqlite3


if __name__ == "__main__":
    database = sqlite3.connect(os.path.join(sys.path[0], 'studentdatabase.db'))
    database.execute(
        '''CREATE TABLE IF NOT EXISTS students (
            studentnumber INTEGER PRIMARY KEY AUTOINCREMENT,
            first_name TEXT NOT NULL,
            last_name TEXT NOT NULL,
            city TEXT NOT NULL,
            date_of_birth DATE NOT NULL,
            class TEXT DEFAULT NULL
        );'''
    )

    def add_student():
        first_name = input("First name: ").removeprefix(" ").removesuffix(" ")
        last_name = input("Last name: ").removeprefix(" ").removesuffix(" ")
        city = input("City: ").removeprefix(" ").removesuffix(" ")
        date_of_birth = input("Date of birth: ").removeprefix(" ").removesuffix(" ")
        student_class = input("Class: ").removeprefix(" ").removesuffix(" ")

        if student_class == "":
            query = '''INSERT INTO students (first_name, last_name, city, date_of_birth) VALUES (?, ?, ?, ?)'''
            query_result = database.execute(query, [first_name, last_name, city, date_of_birth])
            print(query_result.lastrowid)
        else:
            query = '''INSERT INTO students (first_name, last_name, city, date_of_birth, class) VALUES
            (?, ?, ?, ?, ?)'''
            query_result = database.execute(query, [first_name, last_name, city, date_of_birth, student_class])
            print(query_result.lastrowid)

        database.commit()

    def assign_to_class():
        student_number = input("Student number: ").removeprefix(" ").removesuffix(" ")
        new_class = input("Class: ").removeprefix(" ").removesuffix(" ")
        query = '''UPDATE students SET class=? WHERE studentnumber=?'''
        query_result = database.execute(query, (
            new_class,
            student_number
        ))
        if query_result.rowcount < 1:
            print(f"Could not find student with number: {student_number}")
            return
        database.commit()

    def list_all():
        query = '''SELECT * FROM students ORDER BY class DESC'''
        for record in database.execute(query):
            print(record)

    def list_class():
        class_to_list = input("Class: ")
        query = '''SELECT * FROM students WHERE class=? ORDER BY studentnumber'''
        for record in database.execute(query, [class_to_list]):
            print(record)

    def search_student():
        search_term = input("Search term (First name, Last name or City): ")
        query = '''SELECT * FROM students WHERE first_name=? OR last_name=? OR city=? LIMIT 1'''
        for record in database.execute(query, (search_term, search_term, search_term)):
            print(record)

    while True:
        user_input = input("[A] Add new student\n"
                           "[C] Assign student to class\n"
                           "[D] List all students\n"
                           "[L] List all students in class\n"
                           "[S] Search student\n"
                           "[Q] Quit program\n")
        if user_input.lower() == "q":
            break
        elif user_input.lower() == "a":
            add_student()
        elif user_input.lower() == "c":
            assign_to_class()
        elif user_input.lower() == "d":
            list_all()
        elif user_input.lower() == "l":
            list_class()
        elif user_input.lower() == "s":
            search_student()

    database.close()
