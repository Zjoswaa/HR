# Phone Book Management System
phone_book = {}


def add_or_update_contact(name, phone_number, email):  # Function to add or update contact
    if name in phone_book:  # if name in phonebook update phone number and email
        phone_book[name]["phone_number"] = phone_number
        phone_book[name]["email"] = email
        return f"{name} has been updated"
    else:  # if not add new name,phone number and email
        phone_book[name] = {"phone_number": phone_number, "email": email}
        return f"{name} has been added to the phone book"


def remove_contact(name):  # Function to remove contact by name
    if name in phone_book:  # check if name in phone book delete it
        del phone_book[name]
        return f"{name} has been removed from the phone book"
    return f"No contact found with phone number {phone_number}"  # if no contact return this message


def search_contact(name):  # Function to search information by name
    if name in phone_book:
        contact = phone_book[name]  # search for contact by name in phone_book
        return f"Contact found. Name: {name}, Phone: {contact['phone_number']}, Email: {contact['email']}"
    else:
        return f"{name} is not in the phone book"


def search_by_number(phone_number):  # Function to search information by phone number
    for name, details in phone_book.items():  # if phone number found return detailed contact
        return f"Contact found. Name: {name}, Phone: {phone_number}, Email: {details['email']}"
    return f"No contact found with phone number {phone_number}."  # if not return no contact found


def list_all_contacts():  # Function of all contacts in the phone book
    if not phone_book:  # Check if the phone book is empty
        return ["The phone book is empty."]
    contacts_list = []  # Create an empty list to store contact details
    for name, details in phone_book.items():
        contacts_list.append(f"Name: {name}, Phone: {details['phone_number']}, Email: {details['email']}")
    return contacts_list


##### DO NOT EDIT THE CODE BELOW THIS LINE #####

# Main menu
while True:
    print("\nPhone Book Menu:")
    print("[1] Add or Update Contact")
    print("[2] Remove Contact")
    print("[3] Search Contact by Name")
    print("[4] Search Contact by Phone Number")
    print("[5] List All Contacts")
    print("[6] Exit")

    choice = input("Enter your choice (1-6): ")

    if choice == "1":
        name = input("Enter name: ")
        phone_number = input("Enter phone number: ")
        email = input("Enter email: ")
        result = add_or_update_contact(name, phone_number, email)
        print(result)

    elif choice == "2":
        name = input("Enter the name to remove: ")
        result = remove_contact(name)
        print(result)

    elif choice == "3":
        name = input("Enter name to search: ")
        result = search_contact(name)
        print(result)

    elif choice == "4":
        phone_number = input("Enter phone number to search: ")
        result = search_by_number(phone_number)
        print(result)

    elif choice == "5":
        result = list_all_contacts()
        if result:
            print("\n".join(result))
        else:
            print("The phone book is empty.")

    elif choice == "6":
        print("Goodbye!")
        break

    else:
        print("Invalid choice. Please try again.")