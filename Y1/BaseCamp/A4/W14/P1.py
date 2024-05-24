def get_num_of_vowels(inp: str) -> int:
    vowels = ("a", "e", "i", "o", "u")
    vowel_count = 0

    for char in inp:
        if char in vowels:
            vowel_count += 1

    return vowel_count


def sort_basedon_vowels():
    cases = ['code', 'programming', 'description', 'fly', 'free']
    print(sorted(cases, key=get_num_of_vowels))


if __name__ == "__main__":
    sort_basedon_vowels()
