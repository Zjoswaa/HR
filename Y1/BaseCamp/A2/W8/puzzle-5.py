hands = {
    1: "R6 HV H5 H4 ST",
    2: "HK R2 K4 S6 H3",
    3: "R9 K4 R7 H9 KV",
    4: "R8 RV S7 RK KT",
    5: "H9 KT H6 H4 R6",
    6: "R9 RB R8 HB KT",
    7: "HB H5 R4 S8 K8",
    8: "SK K2 H4 KA KV",
    9: "R4 KK RA R5 RT",
    10: "HK K5 SB S7 R4",
    11: "R5 HA S5 H3 KV",
    12: "S9 RV ST S4 R3",
    13: "K6 RB S9 R2 S7",
    14: "R4 KT K5 H6 S8",
    15: "HK H6 KV KB H7",
    16: "HB R8 HV S7 K9",
    17: "S3 SB SV R5 K9",
    18: "K7 S6 K4 H2 S7",
    19: "H5 R6 K6 S7 H3",
    20: "R9 KB K2 RT R4",
    21: "S7 HT H2 HV H3",
    22: "K7 S7 RA H2 HV",
    23: "HT K5 KB ST S3",
    24: "HT RT K6 R6 S7",
    25: "S2 HK S3 R3 RA",
    26: "K4 RA S3 S6 K8",
    27: "K8 R4 H9 R2 ST",
    28: "R6 R5 H7 K4 K8",
    29: "R4 KB K5 KK SB",
    30: "S9 H4 S2 H6 S5",
    31: "K2 SA H6 HV SK",
    32: "KA R5 K2 S5 RT",
    33: "SB KA RV HB ST",
    34: "K5 S3 R4 K7 HV",
    35: "RK HV RB S6 H4",
    36: "HB S2 SA K7 KB",
    37: "KA K3 KT R7 KV",
    38: "S5 R8 SA K8 RA",
    39: "SK K8 K9 S3 R5",
    40: "S4 R6 H8 R2 HV",
    41: "SK SV H3 KV H7",
    42: "H2 HK S5 KB HV",
    43: "KK SA KT H3 S7",
    44: "ST H3 K6 H6 RA",
    45: "K6 RK H3 S4 S3",
    46: "R4 HB R3 S9 KB",
    47: "S2 K4 K5 K7 R3",
    48: "SK K3 SA R9 S8",
    49: "HK SV H5 R4 K8",
    50: "S7 R7 RK H3 HK",
    51: "HB HV K2 KA S9",
    52: "KT H4 KA S8 K7",
    53: "K8 R3 H8 HB SA",
    54: "K9 ST KK HA H2",
    55: "H8 S9 R8 SA R5",
    56: "K8 H9 H8 K2 HA",
    57: "HB K5 S2 S9 K8",
    58: "H9 S9 KB K3 S2",
    59: "KV H5 S2 KK H9",
    60: "K2 H6 KT H4 HA",
    61: "S4 S6 HK K5 K2",
    62: "H3 KA S3 S8 H5",
    63: "SK S8 HK KV R4",
    64: "KV H4 HB ST KT",
    65: "H8 K5 R6 KA S3",
    66: "K9 HK H6 SK K5",
    67: "RB SV H8 R5 K2",
    68: "K6 S4 S7 K2 S3",
    69: "S7 SB HK KB S9",
    70: "SB RT R3 KA K3",
    71: "H7 H3 KB RV K6",
    72: "K5 SB K6 S3 R9",
    73: "H9 SV S8 S9 R5",
    74: "SB R2 R9 SV HT",
    75: "R2 RK K2 K4 R4",
    76: "HA RA K5 RK S3",
    77: "R4 S5 H6 RA KT",
    78: "R2 SK HA R3 H4",
    79: "S8 K9 R7 R3 K6",
    80: "H8 S9 H3 S5 S7",
    81: "H4 SV R8 H5 R3",
    82: "SV R8 KK K8 K3",
    83: "RB KT H6 RA K9",
    84: "ST H3 RV SV R7",
    85: "KB KK K4 SV HK",
    86: "KV SB H3 K8 H8",
    87: "S6 KK K2 R5 R9",
    88: "R4 RV RK RA S7",
    89: "SA H5 R6 R2 K3",
    90: "HB K9 K7 K3 S6",
    91: "H5 S2 S3 K5 KA",
    92: "HK R3 KT S3 KB",
    93: "KA S9 R3 R6 H3",
    94: "KB S9 S6 K4 R9",
    95: "HB R9 KK R6 K4",
    96: "RV S3 K5 KA R7",
    97: "KB H8 SA K8 R6",
    98: "R3 K3 S6 HV H3",
    99: "K2 H9 K5 S2 S4",
    100: "ST H6 R2 KK K3"
}

highest_hand = [0, 0]

for hand_number, hand in hands.items():
    current_hand_score = 0
    for card in hand.split(" "):
        if card[0] == "S":
            current_hand_score += 10
        elif card[0] == "H":
            current_hand_score += 5
        if card[1].isdigit():
            current_hand_score += int(card[1])
        else:
            if card[1] == "A":
                current_hand_score += 1
            elif card[1] == "T":
                current_hand_score += 10
            elif card[1] == "B":
                current_hand_score += 11
            elif card[1] == "V":
                current_hand_score += 12
            elif card[1] == "K":
                current_hand_score += 13
    if current_hand_score > highest_hand[1]:
        highest_hand[0] = hand_number
        highest_hand[1] = current_hand_score

print(highest_hand)
