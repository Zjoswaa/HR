import math

word_encodings = {"PUNT": ".", "UITROEPTEKEN": "!", "ISTEKEN": "=", "VRAAGTEKEN": "?", "NUL": "0", "EEN": "1",
                  "TWEE": "2", "DRIE": "3", "VIER": "4", "VIJF": "5", "ZES": "6", "ZEVEN": "7", "ACHT": "8",
                  "NEGEN": "9"}

encodings = {}

for i in range(1, 677):
    if i <= 26:
        first_letter = "A"
        second_letter = chr(i + 64)
        encodings[i] = f"{first_letter}{second_letter}"
    else:
        first_letter = chr(64 + (math.ceil(i / 26)))
        second_letter = chr(65 + ((i - 1) % 26))
        encodings[i] = f"{first_letter}{second_letter}"

print(encodings)

encoded_message = ""

for num in [386, 122, 327, 449, 118, 607, 492, 12, 128, 209, 608, 18, 215, 529, 512, 369, 410, 115, 118, 624, 128, 587,
            446, 518, 517, 109, 359, 302, 534, 518, 275, 336, 239, 613, 375, 564, 1, 176, 115, 118]:
    encoded_message += encodings[num]

if len(encoded_message) % 2 and encoded_message[-1] == "X":
    encoded_message = encoded_message[:-1]

encoded_message = encoded_message.replace("X", " ")
for encoding in word_encodings:
    encoded_message = encoded_message.replace(encoding, word_encodings[encoding])

print(encoded_message)
