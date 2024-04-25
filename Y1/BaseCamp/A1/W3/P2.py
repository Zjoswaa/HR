import string
original = input("Sentence: ").strip(string.punctuation).lower()
sentence = original.replace(" ", "")


def is_palindrome(_sentence):
    left = 0
    right = len(_sentence) - 1
    while left < right:
        if _sentence[left] != _sentence[right]:
            return False
        left += 1
        right -= 1
    return True


if is_palindrome(sentence):
    print(f"{original} is a palindrome")
else:
    print(f"{original} is not a palindrome")
