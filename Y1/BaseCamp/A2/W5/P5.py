import random


def generate_random_password() -> str:
    password = ""
    for password_length in range(random.randint(7, 10)):
        password += chr(random.randint(33, 126))
    return password


if __name__ == "__main__":
    print(generate_random_password())
