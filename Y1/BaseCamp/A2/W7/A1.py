dict_key_value = {}
encoded_values = []
decoded_values = []


# create a function that given the input string converts it to the encoded equivalent based on the provided or already
# set key/hashmap
# make sure to only convert values that are in the key, if the value is not present, use its own value
def encode_string(data: str, key: str = None) -> str:
    encoded_string = ""
    if key is None:
        for char in data:
            if char in dict_key_value:
                encoded_string += dict_key_value[char]
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


# create a function that given the input string converts it to the decoded equivalent based on the provided or already
# set key/hashmap
# make sure to only decode values that are in the key, if the value is not present, use its own value
def decode_string(data: str, key: str = None) -> str:
    decoded_string = ""
    if key is None:
        for char in data:
            char_found = False
            for _key, _value in dict_key_value.items():
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


# create a function that given a list of inputs converts the complete list to the encoded equivalent based on the
# key/hashmap
# you can use the already created encode function when looping through the list
# tip! make use of the map function within python with a lambda to call the internal function with all elements
# as a return value, you should return a list with the converted values
def encode_list(data: list, key: str = None) -> list:
    if key is None:
        key = ""
        for _key, _value in dict_key_value.items():
            key += _key + _value
    return list(map(lambda x: encode_string(x, key), data))


# create a function that given a list of inputs converts the complete list to the encoded equivalent based on the
# key/hashmap
# you can use the already created decode function when looping through the list
# tip! make use of the map function within python with a lambda to call the internal function with all elements
# as a return value, you should return a list with the converted values
def decode_list(data: list, key: str = None) -> list:
    if key is None:
        key = ""
        for _key, _value in dict_key_value.items():
            key += _key + _value
    return list(map(lambda x: decode_string(x, key), data))


# create a function that given a encoded value, decoded value and a key (optional) checks if the values are correct
# the return value should be a boolean value (True if values match, False if they don't match)
def validate_values(encoded: str, decoded: str, key: str = None) -> bool:
    if key is None:
        key = ""
        for _key, _value in dict_key_value.items():
            key += _key + _value
    return decode_string(encoded, key) == decoded and encode_string(decoded, key) == encoded


# give the option to input a hashvalue to be used/converted to a key
# each uneven character is the Key of the Dict, each even character is the corresponding Value
# you should validate if the given input is an even input, otherwise show the error: Invalid hashvalue input
# example: a@b.c>d#eA will become: {'a': '@', 'b': '.', 'c': '>', 'd', '#', 'e': 'A'}
def set_dict_key(key: str) -> None:
    if len(key) % 2:
        print("Invalid hashvalue input")
        return
    for char in range(0, len(key), 2):
        if not char % 2:
            dict_key_value[key[char]] = key[char + 1]


# build menu structure as following
# the input can be case-insensitive (so E and e are valid inputs)
# [E] Encode value to hashed value
# [D] Decode hashed value to normal value
# [P] Print all encoded/decoded values
# [V] Validate 2 values against eachother
# [Q] Quit program
def main():
    key = input("Key: ")
    if key == "":
        key = None
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
                encoded_values.append(encode_string(item.strip(), key))
        elif user_input.lower() == "d":
            to_decode = input("String: ")
            for item in to_decode.split(","):
                decoded_values.append(decode_string(item.strip(), key))
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
            print(validate_values(encoded_string, decoded_string, key))


# Create a unittest for both the encode and decode function (see test_namehasher.py file for boilerplate)
if __name__ == "__main__":
    main()
