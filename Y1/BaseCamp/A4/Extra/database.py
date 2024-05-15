import sqlite3

if __name__ == "__main__":
    school = sqlite3.connect("school.sqlite")
    query = '''SELECT name, date_of_birth, city FROM students WHERE city=? AND class=?'''
    for record in school.execute(query, ["Bunnik", "BC11C"]):
        print(record)
    school.close()
