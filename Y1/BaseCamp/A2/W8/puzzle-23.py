code = "7943816613186708"

for i_1 in range(1, len(code)):
    for i_2 in range(i_1 + 1, len(code)):
        if int(code[:i_1]) * int(code[i_1:i_2]) == int(code[i_2:]):
            print(f"{code[:i_1]} * {code[i_1:i_2]} = {code[i_2:]}")
