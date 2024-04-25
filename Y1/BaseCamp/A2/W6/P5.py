MORSE_CODE_DICT = {
    'A': '.-', 'B': '-...',
    'C': '-.-.', 'D': '-..', 'E': '.',
    'F': '..-.', 'G': '--.', 'H': '....',
    'I': '..', 'J': '.---', 'K': '-.-',
    'L': '.-..', 'M': '--', 'N': '-.',
    'O': '---', 'P': '.--.', 'Q': '--.-',
    'R': '.-.', 'S': '...', 'T': '-',
    'U': '..-', 'V': '...-', 'W': '.--',
    'X': '-..-', 'Y': '-.--', 'Z': '--..',
    '1': '.----', '2': '..---', '3': '...--',
    '4': '....-', '5': '.....', '6': '-....',
    '7': '--...', '8': '---..', '9': '----.',
    '0': '-----', ',': '--..--', '.': '.-.-.-',
    '?': '..--..'}


def message_to_morse(message):
    morse_message = ""
    for word in message.split(" "):
        morse_word = ""
        for char in word:
            if char.upper() not in MORSE_CODE_DICT:
                print(
                    f"Can't convert char [{char}]")
            else:
                morse_word += MORSE_CODE_DICT[char.upper()] + " "
        morse_message += morse_word.strip() + "    "

    return morse_message


def morse_to_message(morse):
    message = ""
    for letter in morse.split(" "):
        if letter == "" and message[-1] != " ":
            message += " "
        else:
            for item in MORSE_CODE_DICT:
                if MORSE_CODE_DICT[item] == letter:
                    message += item.lower()
    return message


def translate_text(text):
    for letter in text:
        if letter not in ["-", ".", " "]:
            return message_to_morse(text)
    return morse_to_message(text)


if __name__ == "__main__":
    print(translate_text(input()))
