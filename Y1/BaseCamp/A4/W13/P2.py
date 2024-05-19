import os
import sys
import json
import sqlite3
from datetime import datetime, timedelta


def read_from_json(file_name: str) -> dict:
    with open(file_name, "r", encoding="utf-8") as file:
        return json.load(file)


if __name__ == "__main__":
    con = sqlite3.connect(os.path.join(sys.path[0], 'bookstore.db'))
    con.execute(
        """CREATE TABLE IF NOT EXISTS books (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            isbn TEXT NOT NULL,
            title TEXT NOT NULL,
            author TEXT NOT NULL,
            pages INTEGER NOT NULL,
            year TEXT NOT NULL,
            status TEXT DEFAULT 'AVAILABLE',
            return_date DATE DEFAULT NULL
        );"""
    )

    def synchronize_database():
        search_query = "SELECT * FROM books WHERE isbn=? LIMIT 1"
        insert_query = "INSERT INTO books (isbn, title, author, pages, year) VALUES (?, ?, ?, ?, ?)"
        books = read_from_json("books.json")
        for book in books:
            # If the search query returned no items
            if not len(con.execute(search_query, [book["isbn"]]).fetchall()):
                con.execute(insert_query, [
                    book["isbn"],
                    book["title"],
                    book["author"],
                    book["pages"],
                    book["year"]]
                )
        con.commit()

    def borrow_book():
        search_query = "SELECT * FROM books WHERE (id=? OR isbn=?) AND status=? LIMIT 1"
        update_query = "UPDATE books SET status=?, return_date=? WHERE (id=? OR isbn=?)"

        book_id = input("Id or ISBN: ")
        try:
            duration = int(input("Duration (days): "))
        except ValueError:
            print("Invalid duration")
            return

        # If the search query returned no items
        if not len(con.execute(search_query, [book_id, book_id, "AVAILABLE"]).fetchall()):
            print("Failed to borrow book")
            return
        return_date = (datetime.today() + timedelta(days=duration)).strftime("%d-%m-%Y")
        con.execute(update_query, ["BORROWED", return_date, book_id, book_id])
        con.commit()
        print(f"Borrowed book, return date: {return_date}")

    def return_book():
        search_query = "SELECT return_date FROM books WHERE (id=? OR isbn=?) AND status=? LIMIT 1"
        update_query = "UPDATE books SET status=?, return_date=null WHERE (id=? OR isbn=?)"

        book_id = input("Id or ISBN: ")

        search_result = con.execute(search_query, [book_id, book_id, "BORROWED"]).fetchall()
        # If the search query returned no items
        if not len(search_result):
            print("This book is not currently borrowed")
            return

        book_return_date = datetime.strptime(search_result[0][0], "%d-%m-%Y")

        if (book_return_date - datetime.today()).days < -1:
            print(f"{(abs((book_return_date - datetime.today()).days) - 1) * 0.5:.2f}")
        else:
            print("Returned book")

        con.execute(update_query, ["AVAILABLE", book_id, book_id])
        con.commit()

    def search_book():
        search_query = "SELECT * FROM books WHERE instr(title, ?) OR instr(isbn, ?) OR instr(author, ?)"
        # search_query = "SELECT * FROM books WHERE title=? OR isbn=? OR author=?"
        search_term = input("Search term (Title, ISBN, Author): ")

        search_result = con.execute(search_query, [search_term, search_term, search_term]).fetchall()
        if not len(search_result):
            print("No book found with that search term")
            return
        for book in search_result:
            print(f"{{'id': {book[0]}, 'isbn': '{book[1]}', 'title': '{book[2]}', 'author': '{book[3]}', 'pages': "
                  f"{book[4]}, 'year': '{book[5]}', 'status': '{book[6]}', 'return_date': {book[7]}}}")

    synchronize_database()

    while True:
        user_input = input("[B] Borrow book\n"
                           "[R] Return book\n"
                           "[S] Search book\n"
                           "[Q] Quit program\n")

        if user_input.lower() == "q":
            break
        elif user_input.lower() == "b":
            borrow_book()
        elif user_input.lower() == "r":
            return_book()
        elif user_input.lower() == "s":
            search_book()

    con.close()
