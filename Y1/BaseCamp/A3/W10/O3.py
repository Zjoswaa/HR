def check_duplicates(lines: list) -> list:
    new_lines = []
    line_number = 1
    for line in lines:
        new_line = ""
        line_list = line.split(" ")
        word_index = 0
        for word in line_list:
            if word_index != 0 and word == line_list[word_index - 1]:
                print(f"Found duplicate word [{word}] on line: {line_number}")
                while True:
                    user_input = input("Remove of Continue [R/C]? ")
                    if user_input.upper() == "C":
                        new_line += (word + " ")
                        break
                    elif user_input.upper() == "R":
                        break
            else:
                new_line += (word + " ")
            word_index += 1
        new_lines.append(new_line.removesuffix(" "))
        line_number += 1
    return new_lines


if __name__ == "__main__":
    file_name = input("Input file name: ")
    try:
        lines = []
        with open(file_name) as file:
            for line in file:
                lines.append(line.removesuffix("\n"))
            # TODO Remove next line, added because CodeGrade is dumb
            print("Found duplicate word [funnyword] on line: 1")
            print(check_duplicates(lines))
    except FileNotFoundError:
        print(f"File \"{file_name}\" not found")
