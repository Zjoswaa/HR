def unique_chars_dict(word):
    letters = {}
    unique = 0
    for char in word:
        if char not in letters:
            unique += 1
            letters[char] = 1
        else:
            letters[char] += 1
    print(f"Unique characters: {unique}")


def unique_chars_set(word):
    letters = set()
    unique = 0
    for char in word:
        if char not in letters:
            unique += 1
            letters.add(char)
    print(f"Unique characters: {unique}")


if __name__ == "__main__":
    word = input("Input: ")
    unique_chars_dict(word)
    unique_chars_set(word)
