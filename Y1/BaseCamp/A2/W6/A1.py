import os
import sys
import json

'''
print all contacts in the following format:
======================================
Position: <position>
First name: <firstname>
Last name: <lastname>
Emails: <email_1>, <email_2>
Phone numbers: <number_1>, <number_2>
'''


def display():
    for contact in read_from_json("contacts.json"):
        # CodeGrade does not like when you put something like print(f"First name: {contact["first_name"]}")
        # So I sadly had to do it like this
        contact_id = contact["id"]
        first_name = contact["first_name"]
        last_name = contact["last_name"]
        emails = ", ".join(contact["emails"])
        phone_numbers = ", ".join(contact["phone_numbers"])

        print("======================================")
        print(f"Position: {contact_id}")
        print(f"First name: {first_name}")
        print(f"Last name: {last_name}")

        print(f"Emails: {emails}")
        print(f"Phone numbers: {phone_numbers}")


'''
return list of contacts sorted by first_name or last_name [if blank then unsorted], direction [ASC (default)/DESC])
'''


def list_contacts():
    contacts = read_from_json("contacts.json")
    return sorted(contacts, key=lambda x: (x["first_name"], x["last_name"]))


'''
add new contact:
- first_name
- last_name
- emails = {}
- phone_numbers = {}
'''


def add_contact():
    contacts = read_from_json("contacts.json")
    current_id = len(contacts)
    while True:
        first_name = input("First name: ")
        if first_name.isalpha():
            break
    while True:
        last_name = input("Last name: ")
        if last_name.isalpha():
            break
    while True:
        emails = input("Emails: ").replace(" ", "").split(",")
        for email in emails:
            if "@" not in email:
                continue
        if len(emails) != len(set(emails)):  # Does not contain only unique entries
            continue
        break
    while True:
        phone_numbers = input("Phone numbers: ").replace(" ", "").split(",")
        for phone_number in phone_numbers:
            if not phone_number.isnumeric():
                continue
        if len(phone_numbers) != len(set(phone_numbers)):  # Does not contain only unique entries
            continue
        break
    current_id += 1
    contacts.append({"id": current_id, "first_name": first_name, "last_name": last_name, "emails": emails,
                     "phone_numbers": phone_numbers})
    write_to_json("contacts.json", contacts)


'''
remove contact by ID (integer)
'''


def remove_contact():
    contacts = read_from_json("contacts.json")
    while True:
        id_to_remove = input("ID to remove: ")
        if not id_to_remove.isnumeric():
            continue
        break
    for contact in contacts:
        if contact["id"] == int(id_to_remove):
            contacts.remove(contact)
    write_to_json("contacts.json", contacts)


'''
merge duplicates (automated > same fullname [firstname & lastname])
'''


def merge_contacts():
    contacts = read_from_json("contacts.json")
    merged = {}
    for contact in contacts:  # Go through every contact currently saved
        key = (contact["first_name"], contact["last_name"])  # Get a tuple that contains the first and last name
        if key not in merged:  # If an entry with the same first and last name was not yet found
            merged[key] = contact  # You add it to the new dictionary that stores a contact by first, last name as keys
        else:  # If an entry with the same first and last name was already found
            for email in contact["emails"]:  # Merge emails to the entry that was already found
                if email not in merged[key]["emails"]:  # If that entry does not already contain it
                    merged[key]["emails"].append(email)
            for phone_number in contact["phone_numbers"]:  # Merge phone numbers to the entry that was already found
                if phone_number not in merged[key]["phone_numbers"]:  # If that entry does not already contain it
                    merged[key]["phone_numbers"].append(phone_number)
            if contact["id"] < merged[key]["id"]:
                merged[key]["id"] = contact["id"]
    # Save only the values, which contain the original contacts but now with duplicate first and last names removed
    contacts = list(merged.values())
    write_to_json("contacts.json", contacts)


'''
read_from_json
Do NOT change this function
'''


def read_from_json(filename) -> list:
    addressbook = list()
    # read file
    with open(os.path.join(sys.path[0], filename)) as outfile:
        json_data = json.load(outfile)
        # iterate over each line in data and call the add function
        for contact in json_data:
            addressbook.append(contact)

    return addressbook


'''
write_to_json
Do NOT change this function
'''


def write_to_json(filename, addressbook: list) -> None:
    json_object = json.dumps(addressbook, indent=4)

    with open(os.path.join(sys.path[0], filename), "w") as outfile:
        outfile.write(json_object)


'''
main function:
# build menu structure as following
# the input can be case-insensitive (so E and e are valid inputs)
# [L] List contacts
# [A] Add contact
# [R] Remove contact
# [M] Merge contacts
# [Q] Quit program
Don't forget to put the contacts.json file in the same location as this file!
'''


def main(json_file):
    while True:
        user_input = input("[L] List contacts\n[A] Add contact\n[R] Remove contact\n[M] Merge contacts"
                           "\n[Q] Quit program\n")
        if user_input.lower() == "q":
            break
        elif user_input.lower() == "l":
            display()
        elif user_input.lower() == "a":
            add_contact()
        elif user_input.lower() == "r":
            remove_contact()
        elif user_input.lower() == "m":
            merge_contacts()
        else:
            print("Invalid input")
    # write_to_json(json_file, contacts)


'''
calling main function:
Do NOT change it.
'''


if __name__ == "__main__":
    main("contacts.json")
