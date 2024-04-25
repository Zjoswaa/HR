table = [[True, True], [True, False], [False, True], [False, False]]
print("AND")
for pair in table:
    print(f"{pair[0]} + {pair[1]} = {bool(pair[0] and pair[1])}")
print("OR")
for pair in table:
    print(f"{pair[0]} + {pair[1]} = {bool(pair[0] or pair[1])}")
