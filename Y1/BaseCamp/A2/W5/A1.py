import os
import re
import sys

valid_lines = []
corrupt_lines = []

'''
The validate_data function will check the students.csv line by line for corrupt data.

- Valid lines should be added to the valid_lines list.
- Invalid lines should be added to the corrupt_lines list.

Example input: 0896801,Kari,Wilmore,1970-06-18,INF
This data is valid and the line should be added to the valid_lines list unchanged.

Example input: 0773226,Junette,Gur_ry,1995-12-05,
This data is invalid and the line should be added to the corrupt_lines list in the following format:

0773226,Junette,Gur_ry,1995-12-05, => INVALID DATA: ['0773226', 'Gur_ry', '']

In the above example the studentnumber does not start with '08' or '09',
the last name contains a special character and the student program is empty.

Don't forget to put the students.csv file in the same location as this file!
'''


def is_valid_date(date):
    items = date.split("-")
    if int(items[0]) not in range(1960, 2005):
        return False
    if int(items[1]) not in range(1, 13):
        return False
    if int(items[2]) not in range(1, 32):
        return False
    return True


def is_valid_name(name):
    for char in name.replace(" ", ""):
        if not char.lower() in "abcdefghijklmnopqrstuvwxyz":
            return False
    return True


def validate_data(line):
    invalid_data = []
    items = line.split(",")
    if not re.match(r"(09|08)\d{5}", items[0]):
        invalid_data.append(items[0])
    if not is_valid_name(items[1]):
        invalid_data.append(items[1])
    if not is_valid_name(items[2]):
        invalid_data.append(items[2])
    if not is_valid_date(items[3]):
        invalid_data.append(items[3])
    if items[4].lower() not in ["inf", "tinf", "cmd", "ai"]:
        invalid_data.append(items[4])

    if len(invalid_data) == 0:
        valid_lines.append(line)
    else:
        corrupt_lines.append(f"{line} => INVALID DATA: {invalid_data}")


def main(csv_file):
    with open(os.path.join(sys.path[0], csv_file), newline='') as csv_file:
        # skip header line
        next(csv_file)

        for line in csv_file:
            validate_data(line.strip())

    print('### VALID LINES ###')
    print("\n".join(valid_lines))
    print('### CORRUPT LINES ###')
    print("\n".join(corrupt_lines))


if __name__ == "__main__":
    main('students.csv')
