import string
word = input("String: ").strip(string.punctuation).lower()


def is_palindrome(_word):
    left = 0
    right = len(_word) - 1
    while left < right:
        if _word[left] != _word[right]:
            return False
        left += 1
        right -= 1
    return True


if is_palindrome(word):
    print(f"{word} is a palindrome")
else:
    print(f"{word} is not a palindrome")
