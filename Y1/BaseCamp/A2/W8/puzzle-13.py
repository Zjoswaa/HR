passwords = []

for num_1 in range(10):
    for num_2 in range(10):
        for num_3 in range(10):
            for num_4 in range(10):
                for num_5 in range(10):
                    for num_6 in range(10):
                        passwords.append(f"{num_1}{num_2}{num_3}{num_4}{num_5}{num_6}")


def is_valid_password(password: str) -> bool:
    for number in [str(x) for x in range(10)]:
        if password.count(number) > 2:
            return False
    for i in range(len(password)):
        if i < len(password) - 1:
            if password[i] == password[i + 1]:
                return False
    return True


print(len(list(filter(is_valid_password, passwords))))
