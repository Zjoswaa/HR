def is_valid_password(password):
    if len(password) not in range(8, 21):
        return False
    digits = "0123456789"
    alpha = "abcdefghijklmnopqrstuvwxyz"
    special_chars = {"*", "@", "!", "?"}
    if len(set(password).intersection(special_chars)) > 4:
        return False
    for char in password:
        if not (char in digits or char in alpha or char in alpha.upper() or char in special_chars):
            return False
    return True


if __name__ == "__main__":
    for tries in range(4):
        user_input = input("Password: ")
        if is_valid_password(user_input):
            print("Valid")
            break
        else:
            print("Invalid")
