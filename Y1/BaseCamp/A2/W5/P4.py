def is_integer(unchecked: str) -> bool:
    if not len(unchecked) or unchecked is None:
        return False
    if unchecked[0] in ["+", "-"]:
        for char in unchecked.strip()[1:]:
            if not char.isnumeric():
                return False
    else:
        for char in unchecked.strip():
            if not char.isnumeric():
                return False
    return True


def remove_non_integer(unchecked: str) -> int:
    if is_integer(unchecked.strip()):
        return int(unchecked)
    else:
        sign_found = False
        resulting_integer = ""
        for char in unchecked:
            if char.isnumeric():
                resulting_integer += char
            elif char in ["+", "-"] and not sign_found:
                sign_found = True
                resulting_integer += char
        return int(resulting_integer)


if __name__ == "__main__":
    user_input = input("Input: ")
    print("Valid integer") if is_integer(user_input) else print("Invalid integer")
