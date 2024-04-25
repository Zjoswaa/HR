import random


def generate_password(words: list) -> str:
    password = ""
    while len(password) < 8 or len(password) > 10:
        password = ""
        for index in range(2):
            password += random.choice(words).capitalize()

    return password


if __name__ == "__main__":
    file_name = input("Input file name: ")
    try:
        words = []
        with open(file_name) as file:
            for line in file:
                if len(line) >= 3:
                    words.append(line.lower().removesuffix("\n"))
        print(generate_password(words))
        file.close()
    except FileNotFoundError:
        print(f"File \'{file_name}\" not found")
