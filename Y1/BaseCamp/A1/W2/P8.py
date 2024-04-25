import re

valid_patterns = [
    r"[A-Z]{2}-\d{2}-\d{2}",
    r"\d{2}-\d{2}-[A-Z]{2}",
    r"\d{2}-[A-Z]{2}-\d{2}",
    r"[A-Z]{2}-\d{2}-[A-Z]{2}",
    r"[A-Z]{2}-[A-Z]{2}-\d{2}",
    r"\d{2}-[A-Z]{2}-[A-Z]{2}",
    r"\d{2}-[A-Z]{3}-\d",
    r"\d-[A-Z]{3}-\d{2}",
    r"[A-Z]{2}-\d{3}-[A-Z]",
    r"[A-Z]-\d{3}-[A-Z]{2}",
    r"[A-Z]{3}-\d{2}-[A-Z]",
    r"\d-[A-Z]{2}-\d{3}"
]

license_plate = input("License: ")
for pattern in valid_patterns:
    if re.match(pattern, license_plate):
        print("Valid")
        exit(0)
print("Invalid")
