# Same as puzzle 4

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

encoded_message = ""

for num in [31, 447, 265, 362, 607, 488, 115, 118, 109, 358, 577, 125, 228, 457, 120, 499, 265, 359, 228, 457, 120, 499,
            265, 362]:
    encoded_message += encodings[num]

if len(encoded_message) % 2 and encoded_message[-1] == "X":
    encoded_message = encoded_message[:-1]

encoded_message = encoded_message.replace("X", " ")
for encoding in word_encodings:
    encoded_message = encoded_message.replace(encoding, word_encodings[encoding])

print(encoded_message)
# 12!! = 46080
# VIERZESNULACHTNULX
# LX: 310
