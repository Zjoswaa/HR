hashmap_key_value = {}
encoded_values = []
decoded_values = []


def encode_string(data: str, hofunction) -> str:
    return hofunction(data)


def decode_string(data: str, hofunction) -> str:
    return hofunction(data)


def encode_list(data: list, hofunction) -> list:
    return hofunction(data)


def decode_list(data: list, hofunction) -> list:
    return hofunction(data)


def validate_values(encoded: str, decoded: str, hofunction) -> bool:
    return hofunction(encoded, decoded)


def main():
    def encode_hash(data: str, key: str = None) -> str:
        encoded_string = ""
        if key is None:
            for char in data:
                if char in hashmap_key_value:
                    encoded_string += hashmap_key_value[char]
                else:
                    encoded_string += char

            return encoded_string

        for char in data:
            index = key.find(char)
            if index == -1:  # Key does not contain the character
                encoded_string += char
            else:
                encoded_string += key[index + 1]

        return encoded_string

    def decode_hash(data: str, key: str = None) -> str:
        decoded_string = ""
        if key is None:
            for char in data:
                char_found = False
                for _key, _value in hashmap_key_value.items():
                    if char == _value:
                        char_found = True
                        decoded_string += _key
                if not char_found:
                    decoded_string += char

            return decoded_string
        for char in data:
            index = key.find(char)
            if index == -1:  # Key does not contain the character
                decoded_string += char
            else:
                decoded_string += key[index - 1]

        return decoded_string

    def encode_list_hash(data: list, key: str = None) -> list:
        if key is None:
            key = ""
            for _key, _value in hashmap_key_value.items():
                key += _key + _value
        return list(map(lambda x: encode_string(x, key), data))

    def decode_list_hash(data: list, key: str = None) -> list:
        if key is None:
            key = ""
            for _key, _value in hashmap_key_value.items():
                key += _key + _value
        return list(map(lambda x: decode_string(x, key), data))

    def validate_values_hash(encoded: str, decoded: str, key: str = None) -> bool:
        if key is None:
            key = ""
            for _key, _value in hashmap_key_value.items():
                key += _key + _value
        return decode_string(encoded, key) == decoded and encode_string(decoded, key) == encoded

    key = "A%B&C(D)E*F+G-H/I0J<K=L1M!N9O?P>Q7R#S5T;U:V[W]X~Y$Z@"
    while True:
        if len(key) % 2:
            print("Invalid hashvalue input")
            break
        user_input = input("[E] Encode value to hashed value\n"
                           "[D] Decode hashed value to normal value\n"
                           "[P] Print all encoded/decoded values\n"
                           "[V] Validate 2 values against eachother\n"
                           "[Q] Quit program\n")
        if user_input.lower() == "q":
            break
        elif user_input.lower() == "e":
            to_encode = input("String: ")
            for item in to_encode.split(","):
                encoded_values.append(encode_string(item, encode_hash(item.strip(), key)))
        elif user_input.lower() == "d":
            to_decode = input("String: ")
            for item in to_decode.split(","):
                decoded_values.append(decode_string(item, decode_hash(item.strip(), key)))
        elif user_input.lower() == "p":
            if len(encoded_values):
                for item in encoded_values:
                    print(item)
            if len(decoded_values):
                for item in decoded_values:
                    print(item)
        elif user_input.lower() == "v":
            encoded_string = input("Encoded string: ")
            decoded_string = input("Decoded string: ")
            print(validate_values(encoded_string, decoded_string, validate_values_hash(encoded_string, decoded_string, key)))


# Create a unittest for both the encode and decode function (see test_namehasher.py file for boilerplate)
if __name__ == "__main__":
    main()
