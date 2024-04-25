books = []


def search_book(_books, term):
    for book in _books:
        if term in book["title"] or term in book["author"] or term in book["publisher"] or term in book["pub_date"]:
            print(f"Found a book for: {term}")
            return True
    return False


def add_book(details):
    items = details.strip().split(",")
    if not search_book(books, items[0]):
        books.append({"title": items[0], "author": items[1], "publisher": items[2], "pub_date": items[3]})
        print("Book has been added")


if __name__ == "__main__":
    while True:
        user_input = input("[A] Add book\n[S] Search book\n[E] Exit (and print)")
        if user_input.lower() == "e":
            for book in books:
                print(book)
            break
        elif user_input.lower() == "a":
            add_book(input("Book details: "))
        elif user_input.lower() == "s":
            search_book(books, input("Search term: "))
        else:
            print("Invalid input")
