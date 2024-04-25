unique_letters = sorted(set(list("CHATGPT" + "DECEIVE")))
counter = {}

# print(unique_letters)

for char in unique_letters:
    counter[char] = 0


def check_sum() -> bool:
    found_numbers = set()
    for count in counter.values():
        if count in found_numbers:
            return False
        else:
            found_numbers.add(count)

    chatgpt_num = ""
    deceive_num = ""
    for char in list("CHATGPT"):
        chatgpt_num += str(counter[char])
    chatgpt_num = int(chatgpt_num)
    for char in list("DECEIVE"):
        deceive_num += str(counter[char])
    deceive_num = int(deceive_num)

    if chatgpt_num * 2 == deceive_num:
        return True

    return False


def increase_counter():
    if counter["V"] < 9:
        counter["V"] += 1
    else:
        counter["V"] = 0
        if counter["T"] < 9:
            counter["T"] += 1
        else:
            counter["T"] = 0
            if counter["P"] < 9:
                counter["P"] += 1
            else:
                counter["P"] = 0
                if counter["I"] < 9:
                    counter["I"] += 1
                else:
                    counter["I"] = 0
                    if counter["H"] < 9:
                        counter["H"] += 1
                    else:
                        counter["H"] = 0
                        if counter["G"] < 9:
                            counter["G"] += 1
                        else:
                            counter["G"] = 0
                            if counter["E"] < 9:
                                counter["E"] += 1
                            else:
                                counter["E"] = 0
                                if counter["D"] < 9:
                                    counter["D"] += 1
                                else:
                                    counter["D"] = 0
                                    if counter["C"] < 9:
                                        counter["C"] += 1
                                    else:
                                        counter["C"] = 0
                                        if counter["A"] < 9:
                                            counter["A"] += 1
                                        else:
                                            pass


while True:
    if check_sum():
        print("CHEAT: ")
        for char in list("CHEAT"):
            print(f"{counter[char]}", end="")
        print()
        print(counter)
        break
    increase_counter()

# CHATGPT
# 1308478

# DECEIVE
# 2616956

# CHEAT
# 13608
